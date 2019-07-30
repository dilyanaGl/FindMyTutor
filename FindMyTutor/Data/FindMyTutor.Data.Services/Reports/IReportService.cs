using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FindMyTutor.Data.Services.Reports
{
    public interface IReportService
    {
        Task<int> ReportComment(ReportedCommentDTO dto);

        Task<int> ReportOffer(ReportedOfferDTO dto);

        Task<int> RemoveReportedComment(int reportedCommentId);

        Task<int> RemoveReportedOffer(int reportedOfferId);      

        IEnumerable<ReportedOffer> GetReportedOffers();

        IEnumerable<ReportedComment> GetReportedComments();


    }
}
