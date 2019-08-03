using FindMyTutor.Data;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Logs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using FindMyTutor.Common;
using Moq;

namespace UnitTests.LogTests
{
    public class LogTest
    {
        [Fact]
        public void Test_GetAllLogs_ShouldReturnCorrectResult()
        {
            var logs = new Log[]
            {
                new Log
                {
                    Id = 124,
                    UserId = "a",
                    ResourceId = 1,
                    LogType = LogType.AddedAComment
                },
                  new Log
                {
                    Id = 123,
                    UserId = "a",
                    ResourceId = 1,
                    LogType = LogType.AddedAComment
                },
                    new Log
                {
                    Id = 121,
                    UserId = "a",
                    ResourceId = 1,
                    LogType = LogType.AddedAComment
                },
                      new Log
                {
                    Id = 122,
                    UserId = "a",
                    ResourceId = 1,
                    LogType = LogType.AddedAComment
                }
            };

            var mockRepo = new Mock<IRepository<Log>>();
            mockRepo.Setup(p => p.All()).Returns(logs.AsQueryable());

            var serviceMock = new Mock<LogService>(mockRepo.Object);
            var allLogs = serviceMock.Object.GetAllLogs();        

            
            Assert.Equal(4, allLogs.Count());
        }

        [Fact]
        public async Task Test_AddLog_ShouldAddLog()
        {
            var context = GetContext();
            var repo = new DbRepository<Log>(context);
            
            var logService = new LogService(repo);

            var log = new Log
            {
                Id = 122,
                UserId = "a",
                ResourceId = 1,
                LogType = LogType.AddedAComment
            };

            int result = await logService.AddLog(log);

            Assert.Single(context.Log);
        }

        private FindMyTutorWebContext GetContext()
        {

            var options = new DbContextOptionsBuilder<FindMyTutorWebContext>()
                         .UseInMemoryDatabase(databaseName: "FindMyTutor_InMemory_Database")
                         .EnableSensitiveDataLogging()
                         .Options;
            var context = new FindMyTutorWebContext(options);
            return context;

        }



        //IEnumerable<Log> GetAllLogs();

        //Task<int> AddLog(Log dto);
    }
}
