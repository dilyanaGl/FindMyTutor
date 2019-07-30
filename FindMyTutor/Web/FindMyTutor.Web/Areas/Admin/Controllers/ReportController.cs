using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Web.Helpers;
using AutoMapper;
using FindMyTutor.Web.Areas.Admin.Models;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Web.Areas.Admin.Models.Reports;
using FindMyTutor.Data.Services.Comments;

namespace FindMyTutor.Web.Areas.Admin.Controllers
{
    [Area(Constants.Role.Admin)]
    [Authorize(Roles = Constants.Role.Admin)]
    public class ReportController : Controller
    {

        private readonly IReportService reportService;
        private readonly ICommentService commentService;
        private readonly UserManager<FindMyTutorUser> userManager;
        private readonly IMapper mapper;

        public ReportController(IReportService reportService,
            ICommentService commentService,
            UserManager<FindMyTutorUser> userManager, 
            IMapper mapper)
        {
            this.reportService = reportService;
            this.userManager = userManager;
            this.commentService = commentService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var offers = this.reportService.GetReportedOffers()
                .Select(async p => {
                    var model = mapper.Map<FindMyTutor.Data.Models.ReportedOffer, ReportViewModel>(p);
                    model.ReporterName = (await this.userManager.FindByIdAsync(p.ReporterId)).UserName;
                    model.ResourceCreatorName = (await this.userManager.FindByIdAsync(p.ResourceCreatorId)).UserName;
                    return model;
                    }
                )
                .Select(p => p.Result)
                .ToArray();

            var comments = this.reportService.GetReportedComments()
             .Select(async p => {
                 var model = mapper.Map<FindMyTutor.Data.Models.Report, ReportCommentViewModel>(p);
                 model.ReporterName = (await this.userManager.FindByIdAsync(p.ReporterId)).UserName;
                 model.ResourceCreatorName = (await this.userManager.FindByIdAsync(p.ResourceCreatorId)).UserName;
                 return model;
             }
             )
             .Select(p => p.Result)
             .ToArray();

            var reports = new AllReportsViewModel
            {
                Offers = offers,
                Comments = comments
            };

            return View(reports);
        }

        [HttpPost]
        public IActionResult RemoveComment(int commentId)
        {
            this.commentService.RemoveComment(commentId);
            this.reportService.RemoveReportedComment(commentId);

            
            return this.RedirectToAction("Аll");
        }
     
    }
}