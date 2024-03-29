﻿using System;
using System.Linq;
using FindMyTutor.Data.Models;
using FindMyTutor.Data;
using FindMyTutor.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FindMyTutor.Data.Services.DTO;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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

            await this.offers.SaveChangesAsync();

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

           

            int result = await this.offers.SaveChangesAsync();

            return edit.Id;

        }

        public IEnumerable<Offer> GetOfferBySubjectNameId(int subjectNameId)
        {
            return this.offers
                .All()
                .Where(p => p.SubjectId == subjectNameId)
                .ToArray();
        }

        public string GetOfferCreatorId(int offerId)
        {
            var offer = this.offers.All().FirstOrDefault(p => p.Id == offerId);
            if(offer == null)
            {
                return null;
            }
            return offer.TutorId;
            
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

        public IEnumerable<Offer> GetOffersByUser(string userId)
        {
            return this.offers.All()
                .Where(p => p.TutorId == userId)
                .ToArray();
        }

        public string GetTitleById(int offerId)
        {
            return this.offers.All().FirstOrDefault(p => p.Id == offerId).Title;
        }

        public Task<int> RemoveOffer(int id)
        {
             var offer = this.offers
                .All()
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            this.offers.Remove(offer);
            return this.offers.SaveChangesAsync();
        }

        
    }
}
