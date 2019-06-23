using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;


namespace FindMyTutor.Data.Services.Users
{
    public interface IUserService
    {
        IEnumerable<FindMyTutorUser> GetAllTutors();

        FindMyTutorUser GetTutor(string id);
    }
}
