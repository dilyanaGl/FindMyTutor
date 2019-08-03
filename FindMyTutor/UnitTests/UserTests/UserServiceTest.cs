using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Users;
using Moq;
using Xunit;

namespace UnitTests.UserTests
{
    public class UserServiceTest
    {
        FindMyTutorUser[] users;       
        Mock<IRepository<FindMyTutorUser>> mockRepo;
        Mock<UserService> serviceMock;

        public UserServiceTest()
        {
             users = new FindMyTutorUser[]
              {
                new FindMyTutorUser
                {
                    UserName = "Da",
                    Id = "aa",
                    Role = Role.Tutor

                },
                 new FindMyTutorUser
                {
                    UserName = "Dad",
                    Id = "ac",
                    Role = Role.Tutor

                },
                  new FindMyTutorUser
                {
                    UserName = "Dadaa",
                    Id = "av",
                    Role = Role.User

                },
                   new FindMyTutorUser
                {
                    UserName = "Dada",
                    Id = "ab",
                    Role = Role.Admin

                },
             };
           
            mockRepo = new Mock<IRepository<FindMyTutorUser>>();
            mockRepo.Setup(p => p.All()).Returns(users.AsQueryable());

            serviceMock = new Mock<UserService>(mockRepo.Object);

        }

        [Fact]
        public void Test_GetTutor_ShouldReturnCorrectResult()
        {
            var user1 = serviceMock.Object.GetTutor(users[0].Id);
            Assert.Equal(users[0].UserName, user1.UserName);

            var user2 = serviceMock.Object.GetTutor(users[1].Id);
            Assert.Equal(users[1].UserName, user2.UserName);

            var user3 = serviceMock.Object.GetTutor(users[2].Id);
            Assert.Equal(users[2].UserName, user3.UserName);

            var user4 = serviceMock.Object.GetTutor(users[3].Id);
            Assert.Equal(users[3].UserName, user4.UserName);
        }


        [Fact]
        public void Test_GetAllTutors_ShouldReturnCorrectResult()
        {
            var tutors = serviceMock.Object.GetAllTutors();
            Assert.Equal(2, tutors.Count());
        }


        //IEnumerable<FindMyTutorUser> GetAllTutors();

        //FindMyTutorUser GetTutor(string id);
    }
}
