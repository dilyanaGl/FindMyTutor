﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using FindMyTutor.Data;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Reports;
using AutoMapper;
using FindMyTutor.Data.Services.DTO;
using System.Linq;

namespace UnitTests.ReportTests
{
    public class ReportTests_InMemory
    {

        [Fact]
        public async Task Test_AddCommentReport_ShouldAddCommentReport()
        {
            var context = await this.GetContext();
            var commentRepo = new DbRepository<ReportedComment>(context);
            var offerRepo = new DbRepository<ReportedOffer>(context);
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ReportProfile());
            });

            var mapper = config.CreateMapper();

            var reportService = new ReportService(commentRepo, offerRepo, mapper);
            var reportComment = new ReportedCommentDTO
            {
                ReporterId = "a",
                CreatorId = "b"
            };
            await reportService.ReportComment(reportComment);
            Assert.Equal(2, context.ReportedComment.Count());          

           
        }


        [Fact]
        public async Task Test_AddOfferReport_ShouldAddCommentReport()
        {
            var context = await GetContext();
            var commentRepo = new DbRepository<ReportedComment>(context);
            var offerRepo = new DbRepository<ReportedOffer>(context);
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ReportProfile());
            });

            var mapper = config.CreateMapper();

            var reportService = new ReportService(commentRepo, offerRepo, mapper);
            var reportedOffer = new ReportedOfferDTO
            {
                ReporterId = "a",
                ResourceCreatorId = "b"
            };
            await reportService.ReportOffer(reportedOffer);
            Assert.Equal(2, context.ReportedOffers.Count());


        }

        [Fact]
        public async Task Test_RemoveCommentReport_ShouldRemoveCommentReport()
        {
            var context = await GetContext();
            var commentRepo = new DbRepository<ReportedComment>(context);
            var offerRepo = new DbRepository<ReportedOffer>(context);
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ReportProfile());
            });

            var mapper = config.CreateMapper();

            var reportService = new ReportService(commentRepo, offerRepo, mapper);

            await reportService.RemoveReportedComment(122);
            Assert.Empty(context.ReportedComment);
        }

        [Fact]
        public async Task Test_RemoveReportedOffer_ShouldRemoveOfferReport()
        {
            var context = await GetContext();
            var commentRepo = new DbRepository<ReportedComment>(context);
            var offerRepo = new DbRepository<ReportedOffer>(context);
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ReportProfile());
            });

            var mapper = config.CreateMapper();

            var reportService = new ReportService(commentRepo, offerRepo, mapper);
            await reportService.RemoveReportedOffer(112);
            Assert.Empty(context.ReportedOffers);
        }

        private async Task<FindMyTutorWebContext> GetContext()
        {

            var options = new DbContextOptionsBuilder<FindMyTutorWebContext>()
                         .UseInMemoryDatabase(databaseName: "FindMyTutor_InMemory_Database")
                         .Options;
            var context = new FindMyTutorWebContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var reportedComment = new ReportedComment
            {
                Id = 122,
                ReporterId = "a",
                ResourceCreatorId = "b"
            };
            var reportedOffer = new ReportedOffer
            {
                Id = 112,
                ReporterId = "a",
                ResourceCreatorId = "n"
            };

            context.ReportedComment.Add(reportedComment);
            context.ReportedOffers.Add(reportedOffer);
            await context.SaveChangesAsync();

            return context;

        }
    }
}
