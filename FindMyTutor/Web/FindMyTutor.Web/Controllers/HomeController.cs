using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Web.ViewModels.Home;
using FindMyTutor.Web.ViewModels.Common;
using FindMyTutor.Web.ViewModels;
using FindMyTutor.Data.Services.Subjects;
using FindMyTutor.Web.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using FindMyTutor.Web.ViewModels.HomeView;
using FindMyTutor.Data.Services.Offers;
using AutoMapper;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly IOfferService offerService;
        private readonly IMapper mapper;

        public HomeController(ISubjectService subjectService,
            IOfferService offerService,
            IMapper mapper)
        {
            this.subjectService = subjectService;
            this.offerService = offerService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var subjects = this.subjectService.GetSubjects()
                .Select(p => new SubjectViewModel
                {
                    SubjectId = p.Id,
                    SubjectName = p.Name
                });
            // var levels = this.subjectService.GetLevels();
            var buttonStyles = Constants.ButtonStyles;

            var model = new HomeViewModel
            {
                Subjects = subjects

            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/loadLevels/")]
        public IEnumerable<SelectListItem> GetLevels(int id)
        {
            return this.subjectService
                .GetLevels(id);
        }

        [Route("/loadSubjectNames/{subjectId}/{levelName}")]
        [HttpGet]
        public IEnumerable<SelectListItem> LoadSubjectNames(int subjectId, string levelName)
        {
            return this.subjectService.LoadOfferBasedOnSubjectAndLevel(subjectId, levelName);

        }

        [Route("/getOffersWithSubjectId/{id}")]
        [HttpGet]
        public IEnumerable<OfferIndexViewModel> LoadOffersBySubjectNameId(int id)
        {

            return this.offerService
                .GetOfferBySubjectNameId(id)
                .Select(p => mapper.Map<Offer, OfferIndexViewModel>(p))
                .ToArray();

        }





    }
}
