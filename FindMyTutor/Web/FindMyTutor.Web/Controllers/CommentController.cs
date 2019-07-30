using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Web.ViewModels.Comments;
using FindMyTutor.Data.Services.Comments;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FindMyTutor.Data.Services.DTO;
using Microsoft.AspNetCore.Identity;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Logs;
using FindMyTutor.Data.Services.Reports;
using FindMyTutor.Web.Helpers;

namespace FindMyTutor.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly ILogService logService;
        private readonly IReportService reportService;
        private readonly IMapper mapper;
        private readonly UserManager<FindMyTutorUser> userManager;

        public CommentController(ICommentService commentService,
            ILogService logService,
            IMapper mapper,
            IReportService reportService,
            UserManager<FindMyTutorUser> userManager)
        {
            this.commentService = commentService;
            this.logService = logService;
            this.reportService = reportService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(int id, [FromForm]AddCommentViewModel model)
        {
            // TODO: Add TRY CATCH BLOCK

            if (ModelState.IsValid)
            {
                try
                {
                    model.PublishDate = DateTime.Now;
                    var dto = mapper.Map<AddCommentViewModel, CommentDTO>(model);
                    dto.CommenterId = (await this.userManager.GetUserAsync(User)).Id;
                    dto.PublicationDate = DateTime.Now;
                    var result = await this.commentService.AddComment(dto);
                    var log = new Log
                    {
                        UserId = dto.CommenterId,
                        LogType = LogType.AddedAComment,
                        DateTime = DateTime.Now,
                        ResourceId = result,
                        ResourceType = ResourceType.Comment
                    };
                    int logId = await logService.AddLog(log);
                    //this.TempData["Success"] = Constants.Message.SuccessfulComment;
                    return  this.RedirectToAction("Details", "Offer", new { Id = model.OfferId });
                }
                catch
                {
                    ModelState.AddModelError("error", "Вашият коментар не успя да бъде записан.");
                    return await Task.Run(() => this.RedirectToAction("Details", "Offer", new { Id = model.OfferId }));
                }
            }
            else
            {
                ModelState.AddModelError("error", "there was an error");
                return await Task.Run(() => this.RedirectToAction("Details", "Offer", new { Id = model.OfferId }));
            }


        }



        [HttpGet]
        public IEnumerable<CommentViewModel> GetCommentsForOffer(int id)
        {
            var comments = this.commentService.GetAllCommentsForOffer(id)
                .Select(async (p) =>
                {
                    var model = mapper.Map<Comment, CommentViewModel>(p);
                    var user = await this.userManager.FindByIdAsync(p.CommenterId);
                    model.CommenterName = user.FullName;
                    return model;

                })
                .Select(p => p.Result)
                .ToList();

            return comments;

        }

        [HttpGet]
        [Authorize]
        public IActionResult Report(int id)
        {
            try
            {
                this.ViewData["CommentId"] = id;
                this.ViewData["OfferId"] = this.commentService.GetOfferIdByCommentId(id);
                return this.View();
            }

            catch(Exception ex)
            {
                this.TempData[Constants.ValidationState.InvalidComment] = ex.Message;
                return this.RedirectToAction("Index", "Home");
            }


        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Report(CommentReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = mapper.Map<CommentReportViewModel, ReportedCommentDTO>(model);
                     dto.ReporterId = userManager.GetUserId(HttpContext.User);
                    dto.CreatorId = this.commentService.GetCommentAuthorId(model.CommentId);

                    int result = await this.reportService.ReportComment(dto);
                    var log = new Log
                    {
                        LogType = LogType.ReportedAComment,
                        ResourceId = model.CommentId,
                        UserId = this.userManager.GetUserId(this.HttpContext.User),
                        DateTime = DateTime.Now

                    };
                    int id = await this.logService.AddLog(log);

                    this.TempData["Success"] = Constants.Message.SuccessfulReport;
                    return this.RedirectToAction("Details", "Offer", new { id = model.OfferId});
                }


                catch (Exception ex)
                {
                    this.TempData["Error"] = ex.Message;
                    return  this.RedirectToAction("Details", "Offer", new { id = model.OfferId});
                }
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(p => p.Errors))
                {
                    this.TempData["Error"] += error.ErrorMessage + Environment.NewLine;
                }
                return this.RedirectToAction("Offer", "Details", new { id = model.OfferId });
            }


        }
    }
}