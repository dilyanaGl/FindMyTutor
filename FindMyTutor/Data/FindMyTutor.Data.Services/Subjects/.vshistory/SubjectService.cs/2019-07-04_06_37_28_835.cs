using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using FindMyTutor.Data.Services.Helpers;

namespace FindMyTutor.Data.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> subjects;
        private readonly IRepository<SubjectName> subjectNames;

        public SubjectService(IRepository<Subject> subjects, IRepository<SubjectName> subjectNames)
        {
            this.subjects = subjects;
            this.subjectNames = subjectNames;
        }

        public IEnumerable<SelectListItem> GetLevels(int subjectId)
        {
            var subjectNames = this.subjectNames.All()
                .Where(p => p.SubjectId == subjectId)
                .Select(p => new SelectListItem {
                    Text = p.Level,
                    Value = p.LevelEnglish
                })                
                .ToArray();

            return new HashSet<SelectListItem>(subjectNames, new LevelsComparer());
        }

        public IEnumerable<SelectListItem> GetOthetSubjectNamesById(int subjectNameId)
        {
            var subjectName = this.subjectNames.All().First(p => p.Id == subjectNameId);
            return this.subjects.All().FirstOrDefault(p => p.Id == subjectName.SubjectId)
                .SubCategories.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                })
                .ToArray();
        }

        public string GetSubjectById(int id)
        {
            return this.subjects.All().FirstOrDefault(p => p.Id == id).Name;
        }

        public SubjectName GetSubjectNameById(int id)
        {
            return this.subjectNames.All().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<SelectListItem> GetSubjectNames(int subjectId, string level)
        {
            return this.subjectNames.All()
                .Where(p => p.SubjectId == subjectId && p.LevelEnglish == level)
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                })
                .ToArray();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.subjects
                .All()
                .ToArray();
        }

        public IEnumerable<SelectListItem> LoadOfferBasedOnSubjectAndLevel(int subjectId, string level)
        {
            var subjectNames = this.subjectNames.All()
                .Where(p => p.SubjectId == subjectId && p.LevelEnglish== level)
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                })
                .ToArray();

            return subjectNames;
        }


    }
}
