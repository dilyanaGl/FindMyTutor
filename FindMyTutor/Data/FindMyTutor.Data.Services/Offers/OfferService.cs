using System;
using System.Linq;
using FindMyTutor.Data.Models;
using FindMyTutor.Data;
using FindMyTutor.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FindMyTutor.Data.Services.DTO;

namespace FindMyTutor.Data.Services.Offers
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> offers;

        public OfferService(IRepository<Offer> offers)
        {
            this.offers = offers;
        }

        public void AddOffer(OfferDTO offer)
        {
            throw new NotImplementedException();
        }

        public Offer GetOfferDetails(int id)
        {
            return this.offers.All()
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Offer> GetOffersBySubject(string subject)
        {
            return this.offers.All()
                .Where(p => p.Subject.Name == subject);
        }

        public void RemoveOffer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
