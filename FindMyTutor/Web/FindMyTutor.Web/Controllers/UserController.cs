using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Offers;
using FindMyTutor.Data.Services.Recommendations;
using FindMyTutor.Data.Services.Users;
using FindMyTutor.Web.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindMyTutor.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IOfferService offerService;
        private readonly UserManager<FindMyTutorUser> userManager;
        private readonly IMapper mapper;
        private readonly IRecommendationService recommendationService;

        public UserController(IUserService userService, IOfferService offerService, UserManager<FindMyTutorUser> userManager, 
            IMapper mapper, IRecommendationService recommendationService)
        {
            this.userService = userService;
            this.offerService = offerService;
            this.userManager = userManager;
            this.mapper = mapper;
            this.recommendationService = recommendationService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await this.userManager.GetUserAsync(HttpContext.User);
            var model = this.mapper.Map<FindMyTutorUser, UserProfileViewModel>(user);
            model.Offers = this.offerService.GetOffersByUser(user.Id)
                .Select(p => mapper.Map<Offer, ProfileOfferViewModel>(p))
                .ToArray();
            
            return View(model);
        }
    }
}