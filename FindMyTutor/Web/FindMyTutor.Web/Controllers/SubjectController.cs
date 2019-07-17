using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Data.Services.Subjects;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindMyTutor.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [Route("/loadLevels/{id}")]
        public IEnumerable<SelectListItem> GetLevels(int id)
        {
            var subjects = this.subjectService.GetLevels(id);
            return subjects;            
        }
    }
}