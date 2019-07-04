using System;
using System.Linq;
using FindMyTutor.Data.Models;
using FindMyTutor.Data;
using FindMyTutor.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FindMyTutor.Data.Services.DTO;
using System.Threading.Tasks;

namespace FindMyTutor.Data.Services.Offers
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> offers;

        public OfferService(IRepository<Offer> offers)
        {
            this.offers = offers;
        }

        public async Task<int> AddOffer(OfferDTO model)
        {
            var offer = new Offer
            {
                Title = model.Title,
                Description = model.Description,
                TutorId = model.TutorId,
                PublishDate = DateTime.Now,
                ExpirationDate = model.ExpirationDate,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                SubjectId = model.SubjectId,
                Address = model.Address
                
            };

            await this.offers.Add(offer);           
            
           var result = await this.offers.SaveChangesAsync();

            return offer.Id;
        }

        public async Task<int> EditOffer(EditOfferDTO edit)
        {
            var offer = this.offers.All().FirstOrDefault(p => p.Id == edit.Id);

            offer.ImageUrl = edit.ImageUrl;
            if(edit.Price != null)
            {
                offer.Price = edit.Price;
            }


            offer.Address = edit.Address;
            offer.Description = edit.Description;
            offer.SubjectId = edit.SubjectNameId;
            offer.Title = edit.Title;


            return await this.offers.SaveChangesAsync();

        }

        public IEnumerable<Offer> GetOfferBySubjectNameId(int subjectNameId)
        {
            return this.offers
                .All()
                .Where(p => p.SubjectId == subjectNameId)
                .ToArray();
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

        public Task<int> RemoveOffer(int id)
        {
            var offer = this.offers
                .All()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            this.offers.Remove(offer);
            return this.offers.SaveChangesAsync();
        }
    }
}
