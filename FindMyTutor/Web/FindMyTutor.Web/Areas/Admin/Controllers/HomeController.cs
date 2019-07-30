using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using FindMyTutor.Data.Services.Logs;
using AutoMapper;
using FindMyTutor.Web.Areas.Admin.Models;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Identity;


namespace FindMyTutor.Web.Areas.Admin.Controllers
{
    [Area(Constants.Role.Admin)]
    [Authorize(Roles = Constants.Role.Admin)]
    public class HomeController : Controller
    {
        private readonly ILogService logService;
        private readonly IMapper mapper;
        private readonly UserManager<FindMyTutorUser> userManager;
        private readonly ILogDescriptionBuilder logDescriptionBuilder;

        public HomeController(ILogService logService,
            IMapper mapper,
            UserManager<FindMyTutorUser> userManager,
            ILogDescriptionBuilder logDescriptionBuilder)
        {
            this.logService = logService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.logDescriptionBuilder = logDescriptionBuilder;
        }

        public IActionResult Dashboard()
        {
            var logs = this.logService.GetAllLogs()
                .Select(async p =>
                {
                    var model = mapper.Map<Log, LogViewModel>(p);
                    model.Description = this.logDescriptionBuilder.BuildDescription(p.LogType);

                    model.Username = (await userManager.FindByIdAsync(p.UserId)).UserName;
                    return model;
                })
                .Select(p => p.Result)
                .OrderByDescending(p => p.DateTime)
                .ToArray();
            return View(logs);
        }
    }
}