using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FindMyTutor.Common;
using FindMyTutor.Data;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Comments;
using FindMyTutor.Data.Services.DTO;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace UnitTests.CommentTests
{
    public class CommentTests
    {
        private readonly Comment[] comments;
        private readonly Offer[] offers;
        private Mock<IRepository<Comment>> mockRepo;
        private Mock<CommentService> serviceMock;
        private readonly IMapper mapper;

        public CommentTests()
        {

            offers = new Offer[]
              {
                new Offer
                {
                    Id = 133,
                    TutorId = "a",
                    Description = "Very cool",
                    Title = "Math lessons"

                },
                new Offer
                {
                    Id = 233,
                    TutorId = "b",
                    Description = "Very cool indeed",
                    Title = "Lit lessons"
                },
                 new Offer
                {
                    Id = 333,
                    TutorId = "a",
                    Description = "Amazing",
                    Title = "Algebra lessons"

                },
                new Offer
                {
                    Id = 4,
                    TutorId = "b",
                    Description = "Ghastly",
                    Title = "Vazov lessons"
                }
             };
            comments = new Comment[]
            {
                new Comment
                {
                    Id = 12,
                    OfferId = offers[0].Id,
                    Offer = offers[0],
                    Content = "First Comment"
                },

               new Comment
                {
                    Id = 13,
                    OfferId = offers[1].Id,
                    Offer = offers[1],
                    Content = "Second Comment"
                },

                 new Comment
                {
                    Id = 14,
                    OfferId = offers[2].Id,
                    Offer = offers[2],
                    Content = "Third Comment"
                },


                new Comment
                {
                    Id = 15,
                    OfferId = offers[3].Id,
                    Offer = offers[3],
                    Content = "Fourth Comment"
                },

            };

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new CommentProfile());
            });

            mapper = config.CreateMapper();

            mockRepo = new Mock<IRepository<Comment>>();
            mockRepo.Setup(p => p.All()).Returns(comments.AsQueryable());
            serviceMock = new Mock<CommentService>(mockRepo.Object, mapper);
        }
        
        [Fact]
        public void Test_GetAllCommentsByOfferId_ShouldReturnCorrectResult()
        {
            Assert.Single(serviceMock.Object.GetAllCommentsForOffer(offers[0].Id));
            Assert.Single(serviceMock.Object.GetAllCommentsForOffer(offers[1].Id));
            Assert.Single(serviceMock.Object.GetAllCommentsForOffer(offers[2].Id));
            Assert.Single(serviceMock.Object.GetAllCommentsForOffer(offers[3].Id));

            Assert.Equal("First Comment", 
                serviceMock.Object.GetAllCommentsForOffer(offers[0].Id).First().Content);
        }

        [Fact]
        public async Task Test_AddComment_ShouldInsertComment()
        {
            var context = await this.GetContext();
            var comment = new CommentDTO
            {
                CommenterId = "a",
                Content = "NewlyAdded"
            };
            var commentRepo = new DbRepository<Comment>(context);
            
            var commentService = new CommentService(commentRepo, mapper);
            int result = await commentService.AddComment(comment);
            await context.SaveChangesAsync();
            Assert.Equal(5, context.Comments.CountAsync().Result);
            Assert.Contains("NewlyAdded", context.Comments.Select(p => p.Content).ToArray());
        }

        private async Task<FindMyTutorWebContext> GetContext()
        {

            var options = new DbContextOptionsBuilder<FindMyTutorWebContext>()
                         .UseInMemoryDatabase(databaseName: "FindMyTutor_InMemory_Database")
                         .Options;
            var context = new FindMyTutorWebContext(options);          


            context.Comments.AddRange(comments);
            int a = await context.SaveChangesAsync();

            return context;

        }

        //IEnumerable<Comment> GetAllCommentsForOffer(int offerId);

        //void RemoveComment(int commentId);

        //Task<int> AddComment(CommentDTO commentDTO);

        //public override int Id { get; set; }

        //public string CommenterId { get; set; }

        //public FindMyTutorUser Commenter { get; set; }

        //public int OfferId { get; set; }

        //public Offer Offer { get; set; }

        //public int Rating { get; set; }

        //public string Content { get; set; }

        //public DateTime PublicationDate { get; set; }

    }
}
