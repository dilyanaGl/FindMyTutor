using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using FindMyTutor.Data;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;
using AutoMapper;
using FindMyTutor.Data.Services.Messages;
using FindMyTutor.Data.Services.DTO;
using System.Linq;

namespace UnitTests.MessagesTests
{
    public class MessageTest_InMemory
    {

        [Fact]
        public async Task AddMessage_ShouldAddMessageCorrectly()
        {
            var context = await this.GetContext();
            var messageRepo = new DbRepository<Message>(context);

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MessageProfile());
            });

            var mapper = config.CreateMapper();

            var service = new MessageService(messageRepo, mapper);

            var dto = new MessageDTO
            {
                SenderId = "a",
                ReceiverId = "d",
                Content = "asas"
            };
            await service.SendMessage(dto);
            Assert.Equal(5, context.Messages.Count());
        }

        private async Task<FindMyTutorWebContext> GetContext()
        {

            var options = new DbContextOptionsBuilder<FindMyTutorWebContext>()
                         .UseInMemoryDatabase(databaseName: "FindMyTutor_InMemory_Database")
                         .EnableSensitiveDataLogging()
                         .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                         .Options
                         ;
            var context = new FindMyTutorWebContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var messages = new Message[]
             {
                new Message
                {
                    Id = 72,
                    SenderId = "a",
                    ReceiverId = "b",
                    Content = "ab"                

                },
                     new Message
                {
                    Id = 32,
                    SenderId = "b",
                    ReceiverId = "a",
                    Content = "absss"

                },
                          new Message
                {
                    Id = 42,
                    SenderId = "e",
                    ReceiverId = "d",
                    Content = "asas"

                },
                               new Message
                {
                    Id = 52,
                    SenderId = "r",
                    ReceiverId = "e",
                    Content = "asasa"

                },

            };


            context.Messages.AddRange(messages);
            int a = await context.SaveChangesAsync();

            return context;

        }
    }
}
