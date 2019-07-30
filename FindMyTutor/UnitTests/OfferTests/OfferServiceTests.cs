using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using FindMyTutor.Data.Services.Offers;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;

namespace UnitTests.OfferTests
{
    public class OfferServiceTests
    {
        Offer[] offers;
        SubjectName[] subjects;
        Mock<IRepository<Offer>> mockRepo;
        Mock<OfferService> serviceMock;

        public OfferServiceTests()
        {
            subjects = new SubjectName[]
             {
                new SubjectName
                {
                    Id = 1,
                    Name = "Math"
                },
                new SubjectName
                {
                    Id = 2,
                    Name = "Literature"
                }
            };


            offers = new Offer[]
              {
                new Offer
                {
                    Id = 1,
                    TutorId = "a",
                    Subject = subjects[0],
                    SubjectId = subjects[0].Id,
                    Description = "Very cool",
                    Title = "Math lessons"

                },
                new Offer
                {
                    Id = 2,
                    TutorId = "b",
                    Subject = subjects[1],
                    SubjectId = subjects[1].Id,
                    Description = "Very cool indeed",
                    Title = "Lit lessons"
                },
                 new Offer
                {
                    Id = 3,
                    TutorId = "a",
                    Subject = subjects[0],
                    SubjectId = subjects[0].Id,
                    Description = "Amazing",
                    Title = "Algebra lessons"

                },
                new Offer
                {
                    Id = 4,
                    TutorId = "b",
                    Subject = subjects[1],
                    SubjectId = subjects[1].Id,
                    Description = "Ghastly",
                    Title = "Vazov lessons"
                }
             };
            var offer = new Offer
            {
                Id = 1,
                TutorId = "a",
                Description = "New Offer"
            };
            mockRepo = new Mock<IRepository<Offer>>();            
            mockRepo.Setup(p => p.All()).Returns(offers.AsQueryable());           
           
            serviceMock = new Mock<OfferService>(mockRepo.Object);

        }

        [Fact]
        public void Test_GetOffersBySubject_ReturnsAllOffers_OfSubject()
        {         
            Assert.Equal(2, serviceMock.Object.GetOffersBySubject("Math").Count());
            Assert.Equal(2, serviceMock.Object.GetOffersBySubject("Literature").Count());
        }

        [Fact]
        public void Test_GetOfferDetails_ReturnsCorrectResult()
        {
            Assert.Equal("Very cool", serviceMock.Object.GetOfferDetails(1).Description);
            Assert.EndsWith("indeed", serviceMock.Object.GetOfferDetails(2).Description);
            Assert.Equal("Amazing", serviceMock.Object.GetOfferDetails(3).Description);
            Assert.Equal("Ghastly", serviceMock.Object.GetOfferDetails(4).Description);

            Assert.Equal("b", serviceMock.Object.GetOfferDetails(4).TutorId);
            Assert.Equal(subjects[1].Id, serviceMock.Object.GetOfferDetails(4).SubjectId);        
            
        }


        [Fact]
        public void Test_GetOffersBySubjectNameId_ShouldRetturnCorrectResult()
        {
            Assert.Equal(2, serviceMock.Object.GetOfferBySubjectNameId(subjects[0].Id).Count());
            Assert.Equal(2, serviceMock.Object.GetOfferBySubjectNameId(subjects[1].Id).Count());
        }

        [Fact]
        public void Test_GetTitleById_ShouldReturnCorrectResult()
        {
            Assert.Equal("Math lessons", serviceMock.Object.GetTitleById(1));
            Assert.Equal("Lit lessons", serviceMock.Object.GetTitleById(2));
            Assert.Equal("Algebra lessons", serviceMock.Object.GetTitleById(3));
            Assert.Equal("Vazov lessons", serviceMock.Object.GetTitleById(4));
        }
  

        [Fact]
        public void Test_GetOfferCreatorId_ShouldReturnCorrectResult()
        {
            Assert.Equal("a", serviceMock.Object.GetOfferCreatorId(1));
            Assert.Equal("b", serviceMock.Object.GetOfferCreatorId(2));
            Assert.Equal("a", serviceMock.Object.GetOfferCreatorId(3
));
            Assert.Equal("b", serviceMock.Object.GetOfferCreatorId(4));
        }


        [Fact]
        public void Test_GetOfferByUser_ShouldReturnCorrectResult()
        {
            Assert.Equal(2, serviceMock.Object.GetOffersByUser("a").Count());
            Assert.Equal(2, serviceMock.Object.GetOffersByUser("b").Count());

            Assert.Contains("Amazing", serviceMock.Object.GetOffersByUser("a").Select(p => p.Description));
            Assert.Contains("Very cool indeed", serviceMock.Object.GetOffersByUser("b").Select(p => p.Description));
            Assert.Contains("Ghastly", serviceMock.Object.GetOffersByUser("b").Select(p => p.Description));
        }
        
        
        [Fact]
        public void Test_AddOffer()
        {

        }

        //Task<int> AddOffer(OfferDTO offer);

        //Task<int> RemoveOffer(int id);

        //Task<int> EditOffer(EditOfferDTO offer);

      
    }
}
