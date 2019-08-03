using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;

namespace FindMyTutor.Data.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ReportedComment> reportedComments;
        private readonly IRepository<ReportedOffer> reportedOffers;
        private readonly IRepository<Comment> comments;
        private readonly IMapper mapper;

        public ReportService(IRepository<ReportedComment> reportedComments,
            IRepository<ReportedOffer> reportedOffers,
            IRepository<Comment> comments,
            IMapper mapper)
        {
            this.reportedComments = reportedComments;
            this.reportedOffers = reportedOffers;
            this.comments = comments;
            this.mapper = mapper;
        }



        public IEnumerable<ReportedComment> GetReportedComments()
        {
            var reportedComments = this.reportedComments.All()
                .ToArray();

            return reportedComments;
        }

        public IEnumerable<ReportedOffer> GetReportedOffers()
        {
            return this.reportedOffers.All().ToArray();
        }



        public async Task<int> RemoveReportedComment(int commentId)
        {
            var reportedComments = this.reportedComments.All()
                .Where(p => p.CommentId == commentId)
                .ToArray();

            foreach (var reportedComment in reportedComments)
            {
                this.reportedComments.Remove(reportedComment);
            }

            return await this.reportedComments.SaveChangesAsync();

        }

        public async Task<int> RemoveReportedOffer(int reportedOfferId)
        {
            var reportedOffers = this.reportedOffers.All()
                .Where(p => p.Id == reportedOfferId)
                .ToArray();

            foreach (var reportedOffer in reportedOffers)
            {
                this.reportedOffers.Remove(reportedOffer);
            }

            return await this.reportedOffers.SaveChangesAsync();
        }

        public async Task<int> ReportComment(ReportedCommentDTO dto)
        {
            var report = mapper.Map<ReportedCommentDTO, ReportedComment>(dto);
            await this.reportedComments.Add(report);
            return await this.reportedComments.SaveChangesAsync();

        }

        public async Task<int> ReportOffer(ReportedOfferDTO dto)
        {
            var offer = mapper.Map<ReportedOfferDTO, ReportedOffer>(dto);
            await this.reportedOffers.Add(offer);
            return await this.reportedOffers.SaveChangesAsync();
        }
    }
}
