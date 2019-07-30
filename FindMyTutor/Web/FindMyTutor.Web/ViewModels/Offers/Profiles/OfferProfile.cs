using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Web.ViewModels.HomeView;

namespace FindMyTutor.Web.ViewModels.Offers.Profiles
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDetailsViewModel>()
                  .ForMember(dest => dest.PriceDisplay,
                          opt => opt.MapFrom(
                          src => src.Price == null ? "Цена при запитване" : src.Price.Value.ToString("f2")));

            ////var id = await this.offerService.AddOffer(new OfferDTO
            ////{
            ////    Title = model.Title,
            ////    Description = model.Description,
            ////    TutorId = tutor.Id,
            ////    PublishDate = DateTime.Now,
            ////    ExpirationDate = DateTime.Now.AddDays(14),
            ////    Price = model.Price,
            ////    ImageUrl = model.ImageUrl,
            ////    SubjectId = model.SubjectNameId,
            ////    Address = model.Address
            ////});

            CreateMap<CreateOfferViewModel, OfferDTO>()
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.PublishDate.AddDays(14)))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectNameId));


            CreateMap<Offer, EditOfferViewModel>()
                  .ForMember(dest => dest.SubjectNameId,
                opt => opt.MapFrom(src => src.SubjectId));

            CreateMap<Offer, DeleteOfferViewModel>()
               .ForMember(dest => dest.PriceDisplay,
                         opt => opt.MapFrom(
                         src => src.Price == null ? "Цена при запитване" : src.Price.Value.ToString("f2")));

            CreateMap<EditOfferViewModel, EditOfferDTO>();

            CreateMap<Offer, OfferIndexViewModel>()
                .ForMember(dest => dest.TutorName, opt => opt.MapFrom(
                    src => src.Tutor.FullName));

            CreateMap<EditOfferViewModel, OfferDetailsViewModel>();


            //  var model = new OfferDetailsViewModel
            //  {
            //      OfferId = offer.Id,
            //      PriceDisplay = offer.Price == null ? ,
            //      Address = offer.Address,
            //      Title = offer.Title,
            //      ExpirationDate = offer.ExpirationDate,
            //      PublishDate = offer.PublishDate,
            //      Description = offer.Description,
            //      TutorName = tutor.FullName,
            //      ImageUrl = offer.ImageUrl,
            //      SubjectName = subjectName.Name,
            //      Level = subjectName.Level,
            //      Subject = subject
            //
            //  };

        }
    }
}
