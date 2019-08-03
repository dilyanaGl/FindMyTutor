﻿using AutoMapper;
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
        private readonly ReportedComment[] reports;
        private Mock<IRepository<ReportedComment>> mockCOmmentRepo;
        private Mock<IRepository<ReportedOffer>> mockOfferRepo;
        private Mock<ReportService> serviceMock;
        private readonly IMapper mapper;

        public ReportTest()
        {
            reports = new ReportedComment[]
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

            mockCOmmentRepo = new Mock<IRepository<ReportedOffer>>();
            mockCOmmentRepo.Setup(p => p.All()).Returns(this.reports.AsQueryable());
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ReportProfile());
            });

            mapper = config.CreateMapper();
            serviceMock = new Mock<ReportService>(mockCOmmentRepo.Object, mapper);

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
