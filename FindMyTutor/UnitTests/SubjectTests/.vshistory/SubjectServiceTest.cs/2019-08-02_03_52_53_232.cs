using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Subjects;
using System.Linq;

namespace UnitTests.SubjectTests
{
    public class SubjectServiceTest
    {
        Subject[] subjects;
        SubjectName[] subjectNames;
        Mock<IRepository<Subject>> subjectRepo;
        Mock<IRepository<SubjectName>> subjectNamesRepo;
        Mock<SubjectService> subjectServiceMock;

        public SubjectServiceTest()
        {

            subjects = new Subject[]
            {
                new Subject
                {
                    Id = 1,
                    Name = "Math"
                },
                    new Subject
                {
                    Id = 2,
                    Name = "Lit"
                },
                        new Subject
                {
                    Id = 3,
                    Name = "English"
                },
            };

            subjectNames = new SubjectName[]
             {
                new SubjectName
                {
                    Id = 1,
                    Name = "Algebra",
                    SubjectId = subjects[0].Id
                    
                },
                 new SubjectName
                {
                    Id = 3,
                    Name = "Geometry",
                    SubjectId = subjects[0].Id

                },
                  new SubjectName
                {
                    Id = 5,
                    Name = "Trigonometry",
                    SubjectId = subjects[0].Id

                },
                new SubjectName
                {
                    Id = 2,
                    Name = "Uni",
                    SubjectId = subjects[1].Id
                },
                new SubjectName
                {
                    Id = 4,
                    Name="SAT",
                    SubjectId = subjects[2].Id
                }
            };

               
            subjectRepo = new Mock<IRepository<Subject>>();
            subjectNamesRepo = new Mock<IRepository<SubjectName>>();
            subjectRepo.Setup(p => p.All()).Returns(subjects.AsQueryable());
            subjectNamesRepo.Setup(p => p.All()).Returns(subjectNames.AsQueryable());
            subjectServiceMock = new Mock<SubjectService>(subjectRepo.Object);

        }

        [Fact]
        public void GetSubjects_ShouldReturnCorrectResult()
        {
            Assert.Equal(subjects.Length, subjectServiceMock.Object.GetSubjects().Count());
        }

        [Fact]
        public void GetSubjectById_ShouldReturnCorrectResult()
        {
            Assert.Equal(subjects[0].Id, ser)
        }



        //IEnumerable<Subject> GetSubjects();

        //IEnumerable<SelectListItem> GetLevels(int subjectId);

        //IEnumerable<SelectListItem> GetSubjectNames(int subjectId, string level);

        //SubjectName GetSubjectNameById(int id);

        //string GetSubjectById(int id);

        //IEnumerable<SelectListItem> GetOthetSubjectNamesById(int subjectNameId);

        //IEnumerable<SelectListItem> LoadOfferBasedOnSubjectAndLevel(int subjectId, string level);

    }
}
