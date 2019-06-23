using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Offers
{
    using DTO;

    public interface IOfferService
    {
        IEnumerable<Offer> GetOffersBySubject(string subject);

        Offer GetOfferDetails(int id);

        void AddOffer(OfferDTO offer);

        void RemoveOffer(int id);



    }
}
