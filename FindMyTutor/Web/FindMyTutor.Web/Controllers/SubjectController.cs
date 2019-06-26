﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Data.Services.Subjects;

namespace FindMyTutor.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        ////public IActionResult Index()
        ////{
        ////    return View();
        ////}
        ///
        [Route("/loadLevels/{id}")]
        public IEnumerable<string> GetLevels(int id)
        {
            var subjects = this.subjectService.GetLevels(id);
            return subjects;            
        }
    }
}