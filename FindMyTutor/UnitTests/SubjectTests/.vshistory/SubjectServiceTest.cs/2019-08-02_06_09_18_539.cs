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
        Mock<SubjectService> serviceMock;
        

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
                    SubjectId = subjects[0].Id,
                    Level = "A", 
                    LevelEnglish = "A"
                    
                },
                 new SubjectName
                {
                    Id = 3,
                    Name = "Geometry",
                    SubjectId = subjects[0].Id,
                    Level = "B",
                    LevelEnglish = "B"

                },
                  new SubjectName
                {
                    Id = 5,
                    Name = "Trigonometry",
                    SubjectId = subjects[0].Id,
                    Level = "B",
                    LevelEnglish = "B"

                },
                new SubjectName
                {
                    Id = 2,
                    Name = "Uni",
                    SubjectId = subjects[1].Id,
                    Level = "C",
                    LevelEnglish = "C"
                },
                new SubjectName
                {
                    Id = 4,
                    Name="SAT",
                    SubjectId = subjects[2].Id,
                    Level = "C",
                    LevelEnglish = "C"
                }
            };

               
            subjectRepo = new Mock<IRepository<Subject>>();
            subjectNamesRepo = new Mock<IRepository<SubjectName>>();
            subjectRepo.Setup(p => p.All()).Returns(subjects.AsQueryable());
            subjectNamesRepo.Setup(p => p.All()).Returns(subjectNames.AsQueryable());
            serviceMock = new Mock<SubjectService>(subjectRepo.Object, subjectNamesRepo.Object);
            

        }

        [Fact]
        public void GetSubjects_ShouldReturnCorrectResult()
        {
            Assert.Equal(subjects.Length, serviceMock.Object.GetSubjects().Count());
        }

        [Fact]
        public void GetSubjectById_ShouldReturnCorrectResult()
        {
            Assert.Equal(subjects[0].Name, serviceMock.Object.GetSubjectById(subjects[0].Id));
            Assert.Equal(subjects[1].Name, serviceMock.Object.GetSubjectById(subjects[1].Id));
            Assert.Equal(subjects[2].Name, serviceMock.Object.GetSubjectById(subjects[2].Id));
         
        }

        [Fact]
        public void GetSubjectNameById_ShouldReturnCorrectResult()
        {
            Assert.Equal(subjectNames[0], serviceMock.Object.GetSubjectNameById(subjectNames[0].Id));
            Assert.Equal(subjectNames[1], serviceMock.Object.GetSubjectNameById(subjectNames[1].Id));
            Assert.Equal(subjectNames[2], serviceMock.Object.GetSubjectNameById(subjectNames[2].Id));
            Assert.Equal(subjectNames[3], serviceMock.Object.GetSubjectNameById(subjectNames[3].Id));
        }

        [Fact]
        public void GetLevels_ShouldReturnCorrectResult()
        {
            Assert.Equal(2, this.serviceMock.Object.GetLevels(subjects[0].Id).Count());
            Assert.Single(this.serviceMock.Object.GetLevels(subjects[1].Id));
            Assert.Equal("C", this.serviceMock.Object.GetLevels(subjects[1].Id).First().Text);
            Assert.Single(this.serviceMock.Object.GetLevels(subjects[2].Id));
            Assert.Equal("C", this.serviceMock.Object.GetLevels(subjects[2].Id).First().Text);

        }

        [Fact]
        public void GetSubjectNames_ShouldReturnCorrectResult()
        {
            Assert.Single(this.serviceMock.Object.GetSubjectNames(subjects[0].Id, "A"));
            Assert.Equal(2, this.serviceMock.Object.GetSubjectNames(subjects[0].Id, "B").Count());
        }

        //[Fact]
        //public void GetOtherSubjectNamesById_ShouldReturnCorrectResult()
        //{
        //    var subjectName = this.serviceMock.Object.GetOthetSubjectNamesById(subjectNames[0].Id);
        //    Assert.Equal(3, subjectName.Count());
        //    Assert.Single(this.serviceMock.Object.GetOthetSubjectNamesById(subjectNames[3].Id));
        //    Assert.Single(this.serviceMock.Object.GetOthetSubjectNamesById(subjectNames[4].Id));
        //}

        //IEnumerable<Subject> GetSubjects();

        //IEnumerable<SelectListItem> GetLevels(int subjectId);

        //IEnumerable<SelectListItem> GetSubjectNames(int subjectId, string level);

        //SubjectName GetSubjectNameById(int id);

        //string GetSubjectById(int id);

        //IEnumerable<SelectListItem> GetOthetSubjectNamesById(int subjectNameId);

        //IEnumerable<SelectListItem> LoadOfferBasedOnSubjectAndLevel(int subjectId, string level);

    }
}
