using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using System.Threading.Tasks;


namespace FindMyTutor.Data.Services.Offers
{
    using DTO;

    public interface IOfferService
    {
        IEnumerable<Offer> GetOffersBySubject(string subject);

        Offer GetOfferDetails(int id);

        Task<int> AddOffer(OfferDTO offer);

        Task<int> RemoveOffer(int id);

        Task<int> EditOffer(EditOfferDTO offer);

        IEnumerable<Offer> GetOfferBySubjectNameId(int subjectNameId);
       

    }
}
