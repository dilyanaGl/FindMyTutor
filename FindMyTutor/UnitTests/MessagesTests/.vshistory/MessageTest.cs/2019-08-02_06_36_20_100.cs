using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;
using FindMyTutor.Data.Services.Messages;
using AutoMapper;
using System.Linq;

namespace UnitTests.MessagesTests
{
    public class MessageTest
    {

        private Message[] messages;
        Mock<IRepository<Message>> messageRepo;
        Mock<MessageService> serviceMock;
        private readonly IMapper mapper;

        public MessageTest()
        {
            this.messages = new Message[]
            {
                new Message
                {
                    Id = 1,
                    SenderId ="a",
                    ReceiverId = "b",
                    Content = "ab"
                },
                  new Message
                {
                    Id = 5,
                    SenderId ="e",
                    ReceiverId = "s",
                    Content = "adad"
                },
                    new Message
                {
                    Id = 6,
                    SenderId ="s",
                    ReceiverId = "d",
                    Content = "da"
                },
                      new Message
                {
                    Id = 3,
                    SenderId ="a",
                    ReceiverId = "b",
                    Content = "abaaa"
                },
                      new Message
                {
                    Id = 2,
                    SenderId ="b",
                    ReceiverId = "a",
                    Content = "abcccc"

                }
            };

            messageRepo = new Mock<IRepository<Message>>();
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MessageProfile());
            });

            mapper = config.CreateMapper();
            messageRepo.Setup(p => p.All()).Returns(this.messages.AsQueryable());
            serviceMock = new Mock<MessageService>(messageRepo.Object, mapper);

        }

        [Fact]
        public void Test_GetUserMessages_ReturnsCorrectResult()
        {
            Assert.Equal(3, this.serviceMock.Object.GetUserMessages("a").Count());
            Assert.Single(this.serviceMock.Object.GetUserMessages("e"));
            Assert.Equal(3, this.serviceMock.Object.GetUserMessages("b").Count());
            Assert.Single(this.serviceMock.Object.GetUserMessages("s"));

        }

        [Fact]
        public void Test_GetMessage_ShouldReturnCorrectMessage()
        {
            foreach (var message in this.messages)
            {
                Assert.Equal(message.Content,
                    this.serviceMock.Object.GetMessage(message.Id).Content);
            }
        }

        [Fact]
        public void Test_GetFullCorrespondence_ReturnsCorrectResult()
        {
            Assert.Equal(2, this.serviceMock.Object.GetFullCorrespondence("a", "b").Count());
            Assert.Single(this.serviceMock.Object.GetFullCorrespondence("s", "d"));

        }

        [Fact]
        public void Test_GetMail_ReturnsCorrectResult()
        {
            Assert.Equal(2, 
                this.serviceMock.Object.GetMail("a").Where(p => p.SenderId == "b").Count());
        }

        //IEnumerable<Message> GetUserMessages(string id);

        //Task<int> SendMessage(MessageDTO messageDTO);

        //Task<Message> GetMessage(int id);

        //IEnumerable<Message> GetFullCorrespondence(string senderId, string receiverId);

        //IEnumerable<MailMessageDTO> GetMail(string userId);

    }
}
