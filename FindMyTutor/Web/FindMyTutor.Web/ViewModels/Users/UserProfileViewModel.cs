using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Users
{
    public class UserProfileViewModel
    {
        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public ICollection<ProfileOfferViewModel> Offers { get; set; }
    }
}
