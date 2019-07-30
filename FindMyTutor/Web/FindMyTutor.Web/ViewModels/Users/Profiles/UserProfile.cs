using AutoMapper;
using FindMyTutor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Users.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<FindMyTutorUser, UserProfileViewModel>();
            CreateMap<Offer, ProfileOfferViewModel>();

        }
    }
}
