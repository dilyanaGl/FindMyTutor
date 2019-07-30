using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Authorization.Policies
{
    public class RequireRole : IAuthorizationRequirement
    {
        public RequireRole(string role)
        {
            Role = role;
        }

        public string Role { get; }
    }
}
