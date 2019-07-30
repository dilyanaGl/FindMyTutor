using FindMyTutor.Data;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Data.Services.Offers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading.Tasks;

namespace UnitTests.OfferTests
{

    public class UseInMemoryDatabase
    {      

        [Fact]
        public async Task Test_AddOffer_ShouldAddOffer()
        {


            var offer = new OfferDTO
            {
                TutorId = "100",
                Title = "NewlyAdded"

            };

            var context = await GetContext();
            var offerRepo = new DbRepository<Offer>(context);
            var offerService = new OfferService(offerRepo);
            int result = await offerService.AddOffer(offer);
            Assert.Equal(5, context.Offers.CountAsync().Result);
            Assert.Contains("NewlyAdded", context.Offers.Select(p => p.Title).ToArray());

        }

        [Fact]
        public async Task Test_RemoveOffer_ShouldRemoveOffer()
        {
            var context = await GetContext();        

           var offerRepo = new DbRepository<Offer>(context);
           var offerService = new OfferService(offerRepo);
           int result = await offerService.RemoveOffer(12);
           Assert.Equal(3, context.Offers.Count());           

         }


        [Fact]
        public async Task Test_EditOffer_ShouldUpdateOffer()
        {
            var context = await GetContext();
            var offerRepo = new DbRepository<Offer>(context);
            var offerService = new OfferService(offerRepo);

            var editDto = new EditOfferDTO
            {
                Id = 12,
                Title = "Edited offer"
            };
            int id = await offerService.EditOffer(editDto);
            //int result = await context.SaveChangesAsync();
            var offers = context.Offers.ToArray();
            var editedOfferTitle = offerService.GetTitleById(id);
            Assert.Equal("Edited offer", context.Offers
                .SingleOrDefault(p => p.Id == id)
                .Title);
        }
        //Task<int> AddOffer(OfferDTO offer);

        //Task<int> RemoveOffer(int id);

        private async Task<FindMyTutorWebContext> GetContext()
        {

           var options = new DbContextOptionsBuilder<FindMyTutorWebContext>()
                        .UseInMemoryDatabase(databaseName: "FindMyTutor_InMemory_Database")
                        .EnableSensitiveDataLogging()
                        .Options;
           var context = new FindMyTutorWebContext(options);


            var offers = new Offer[]
             {
                new Offer
                {
                    Id = 12,
                    TutorId = "a",
                    Description = "Very cool",
                    Title = "Math lessons"

                },
                new Offer
                {
                    Id = 22,
                    TutorId = "b",
                    Description = "Very cool indeed",
                    Title = "Lit lessons"
                },
                 new Offer
                {
                    Id = 32,
                    TutorId = "a",
                    Description = "Amazing",
                    Title = "Algebra lessons"

                },
                new Offer
                {
                    Id = 42,
                    TutorId = "b",
                    Description = "Ghastly",
                    Title = "Vazov lessons"
                }
            };


            context.Offers.AddRange(offers);
           int a = await context.SaveChangesAsync();

            return context;

        }



    }
}
