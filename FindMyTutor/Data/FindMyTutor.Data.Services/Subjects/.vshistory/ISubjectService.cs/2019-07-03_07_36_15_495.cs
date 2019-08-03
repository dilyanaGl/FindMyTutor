using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindMyTutor.Data.Services.Subjects
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();

        IEnumerable<SelectListItem> GetLevels(int subjectId);

        IEnumerable<SelectListItem> GetSubjectNames(int subjectId, string level);

        SubjectName GetSubjectNameById(int id);
        
        string GetSubjectById(int id);

        IEnumerable<SelectListItem> GetOthetSubjectNamesById(int subjectNameId);

        IEnumerable<SelectListItem> LoadOfferBasedOnSubjectAndLevel(int subjectId, string level);


    }
}
