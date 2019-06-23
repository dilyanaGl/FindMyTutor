using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;

namespace FindMyTutor.Data.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IRepository<FindMyTutorUser> users;

        public UserService(IRepository<FindMyTutorUser> users)
        {
            this.users = users;
        }

        public IEnumerable<FindMyTutorUser> GetAllTutors()
        {
            return this.users.All()
                .Where(p => p.Role.ToString() == "Tutor")
                .ToList();
        }

        public FindMyTutorUser GetTutor(string id)
        {
            return this.users.All()
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
