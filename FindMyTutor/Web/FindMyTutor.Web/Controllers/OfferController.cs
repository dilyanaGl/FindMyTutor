using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Web.ViewModels.Offers;
using FindMyTutor.Data.Services.Offers;
using FindMyTutor.Data.Services.DTO;
using Microsoft.AspNetCore.Identity;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Subjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using FindMyTutor.Data.Services.Comments;
using AutoMapper;
using FindMyTutor.Web.ViewModels.Comments;
using FindMyTutor.Web.Helpers;
using FindMyTutor.Data.Services.Logs;
using FindMyTutor.Data.Services.Reports;
using System.Security.Claims;

namespace FindMyTutor.Web.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;
        private readonly ISubjectService subjectService;
        private readonly ILogService logService;
        private readonly IReportService reportService;
        private readonly UserManager<FindMyTutorUser> userManager;
        private readonly IMapper mapper;
        private readonly ICommentService commentService;


        public OfferController(IOfferService offerService,
            UserManager<FindMyTutorUser> userManager,
            ISubjectService subjectService,
            ICommentService commentService,
            ILogService logService,
            IReportService reportService,
            IMapper mapper)
        {
            this.offerService = offerService;
            this.userManager = userManager;
            this.subjectService = subjectService;
            this.mapper = mapper;
            this.commentService = commentService;
            this.logService = logService;
            this.reportService = reportService;
        }

        [Authorize(Roles ="Tutor")]
        [HttpGet]
        [Route("/Offer/Create")]
        [Authorize(Policy = "MustBeTutor")]
        public IActionResult Create()
        {


            CreateOfferViewModel model = CreateModel();
            return View(model);
        }

        [NonAction]
        private CreateOfferViewModel CreateModel()
        {

            var subjects = this.subjectService.GetSubjects()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name

                })
            .ToList();

            return new CreateOfferViewModel
            {
                Subjects = subjects
            };

        }

        [Authorize(Roles = "Tutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Offer/Create")]
        [Authorize(Policy = "MustBeTutor")]
        public async Task<IActionResult> Create(CreateOfferViewModel model)
        {

            if (this.ModelState.IsValid)
            {
                var tutor = await userManager.GetUserAsync(HttpContext.User);

                // TO DO: Enable File Uploading for images

                var dto = mapper.Map<CreateOfferViewModel, OfferDTO>(model);

                dto.TutorId = tutor.Id;
                int id = await this.offerService.AddOffer(dto);
                var result = await this.userManager.AddClaimAsync(tutor,
             new System.Security.Claims.Claim("Creator", id.ToString()));

                var log = new Log
                {
                    UserId = this.userManager.GetUserId(HttpContext.User),
                    LogType = LogType.CreatedAnOffer,
                    DateTime = DateTime.Now,
                    ResourceId = id,
                    ResourceType = ResourceType.Comment
                };
                await logService.AddLog(log);
                //return await Task.FromResult<IActionResult>(this.RedirectToRoute("Offer/Details/" + id));
                //this.TempData["Success"] = true;
                return this.RedirectToAction("Details", "Offer", new { id = id});
            }

            foreach (var error in this.ModelState.Values.SelectMany(p => p.Errors))
            {
                this.ViewData["Error"] += error + "/n";

            }

            CreateOfferViewModel createModel = CreateModel();
            return await Task.Run(() => this.View(createModel));

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Offer/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var offer = this.offerService.GetOfferDetails(id);
            if (offer == null)
            {
                this.TempData["InvalidOffer"] = true;
                return await Task.Run(() => this.RedirectToAction("Index", "Home"));
            }
            var tutor = await this.userManager.FindByIdAsync(offer.TutorId);
            var subjectName = this.subjectService.GetSubjectNameById(offer.SubjectId);
            var subject = this.subjectService.GetSubjectById(subjectName.SubjectId);


            var model = mapper.Map<Offer, OfferDetailsViewModel>(offer);

            model.TutorName = tutor.FullName;
            model.TutorId = tutor.Id;
            model.SubjectName = subjectName.Name;
            model.Level = subjectName.Level;
            model.Subject = subject;

            var comments = this.commentService.GetAllCommentsForOffer(id)
               .Select(p =>
               {
                   var commentModel = mapper.Map<Comment, CommentViewModel>(p);
                   var user = this.userManager.FindByIdAsync(p.CommenterId).Result;
                   commentModel.CommenterName = user.FullName;
                   return commentModel;
               })
               .ToList();
            model.Comments = comments;

            return this.View(model);
        }


        [HttpGet]
        [Route("Offer/Edit/{id}")]
        [Authorize(Policy = Constants.Policy.MustBeCreator)]
        public IActionResult Edit(int id)
        {
            var offer = this.offerService.GetOfferDetails(id);
            if (offer == null)
            {
                this.TempData["InvalidOffer"] = true;
                return this.RedirectToAction("Index", "Home");
            }
            var model = mapper.Map<Offer, EditOfferViewModel>(offer);
            ////model.SubjectNames = this.subjectService.GetOthetSubjectNamesById(offer.SubjectId);
            return this.View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Policy = Constants.Policy.MustBeCreator)]
        public async Task<IActionResult> Edit(int id, [Bind("Title, Description, SubjectNameId, Price, SharePriceOption, ImageUrl, Address")]EditOfferViewModel model)
        {
            try
            {
                var offerDto = mapper.Map<EditOfferViewModel, EditOfferDTO>(model);
                offerDto.Id = id;
                var result = await offerService.EditOffer(offerDto);
                var log = new Log
                {
                    UserId = this.userManager.GetUserId(HttpContext.User),
                    LogType = LogType.EditedAnOffer,
                    DateTime = DateTime.Now,
                    ResourceId = result,
                    ResourceType = ResourceType.Offer
                };
                int logResult = await logService.AddLog(log);
                this.TempData[Constants.ValidationState.Success] = Constants.Message.OfferUpdate.Success;
            }
            catch(Exception ex)
            {
                this.TempData[Constants.ValidationState.Error] = ex.Message;
            }          
            
            return this.RedirectToAction("Details", id);
        }

        [HttpGet]
        [Authorize(Policy = Constants.Policy.MustBeCreator)]
        public IActionResult Delete(int id)
        {
            var offer = this.offerService.GetOfferDetails(id);
            var model = mapper.Map<Offer, DeleteOfferViewModel>(offer);
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Policy = Constants.Policy.MustBeCreator)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id, DeleteOfferViewModel model)
        {
            try
            {
                var result = await this.offerService.RemoveOffer(id);
                await this.reportService.RemoveReportedOffer(id);
                this.TempData[Constants.ValidationState.Success] = "Успешно изтрихте оферта.";
            }
            catch (Exception ex)
            {
                this.TempData[Constants.ValidationState.Error] = ex.Message;
            }

            return this.RedirectToAction("Index", "Home", new { area = ""});
        }

        //[Route("/loadLevels/")]
        //public IEnumerable<string> GetLevels(int id)
        //{
        //    return this.subjectService.GetLevels(id);
        //}

        [HttpGet]
        [Authorize]
        public IActionResult Report(int id)
        {
            this.ViewData["OfferId"] = id.ToString();
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Report(int id, ReportOfferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var report = mapper.Map<ReportOfferViewModel, ReportedOfferDTO>(model);
                report.OfferId = id;
                string userId = this.userManager.GetUserId(HttpContext.User);
                report.ReporterId = userId;
                report.ResourceCreatorId = this.offerService.GetOfferCreatorId(id);

                var reportId = await this.reportService.ReportOffer(report);

                var admins = await this.userManager.GetUsersInRoleAsync(Constants.Role.Admin);

                var claim = new Claim("Report", reportId.ToString());

                foreach (var admin in admins)
                {
                    await this.userManager.AddClaimAsync(admin, claim);
                }

                var log = new Log
                {
                    UserId = userId,
                    DateTime = DateTime.Now,
                    ResourceType = ResourceType.Offer,
                    LogType = LogType.ReportedAnOffer,
                    ResourceId = id
                };
                await this.logService.AddLog(log);
                this.TempData["Success"] = Constants.Message.SuccessfulReport;
                return this.RedirectToAction("Details", "Offer", new { id = id});


            }
            else
            {
                return this.View();
            }

        }



    }
}