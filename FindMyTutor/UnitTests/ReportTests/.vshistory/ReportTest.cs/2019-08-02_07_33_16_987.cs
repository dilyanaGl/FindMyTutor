using AutoMapper;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Reports;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.ReportTests
{
    public class ReportTest
    {
        private readonly ReportedComment[] reportedComments;
        private Mock<IRepository<ReportedComment>> mockCommentRepo;
        private Mock<IRepository<ReportedOffer>> mockOfferRepo;
        private Mock<ReportService> serviceMock;
        private readonly IMapper mapper;

        public ReportTest()
        {
            reportedComments = new ReportedComment[]
            {
                new ReportedComment
                {
                    Id = 1, 
                    ReporterId = "a",
                    ResourceCreatorId = "b",
                    Rationale = "bad"
                },
                   new ReportedComment
                {
                    Id = 2,
                    ReporterId = "a",
                    ResourceCreatorId = "b",
                    Rationale = "bad offer"
                },
                      new ReportedComment
                {
                    Id = 3,
                    ReporterId = "a",
                    ResourceCreatorId = "b",
                    Rationale = "bad comment"
                },
                         new ReportedComment
                {
                    Id = 4,
                    ReporterId = "a",
                    ResourceCreatorId = "b",
                    Rationale = "bad"
                },
            };

            mockCommentRepo = new Mock<IRepository<ReportedComment>>();
            mockCommentRepo.Setup(p => p.All()).Returns(this.reportedComments.AsQueryable());
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ReportProfile());
            });

            mapper = config.CreateMapper();
            serviceMock = new Mock<ReportService>(mockCommentRepo.Object, mapper);

        }

        [Fact]
        public void GetReportedOffers_ShouldReturnCorrectResult()
        {
            Ass
        }

        //Task<int> ReportComment(ReportedCommentDTO dto);

        //Task<int> ReportOffer(ReportedOfferDTO dto);

        //Task<int> RemoveReportedComment(int reportedCommentId);

        //Task<int> RemoveReportedOffer(int reportedOfferId);

        //IEnumerable<ReportedOffer> GetReportedOffers();

        //IEnumerable<ReportedComment> GetReportedComments();
    }
}
