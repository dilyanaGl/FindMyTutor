using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.ViewModels.Users
{
    public class ProfileOfferViewModel
    {

        public int Id { get; set; }

        
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }


    }
}
