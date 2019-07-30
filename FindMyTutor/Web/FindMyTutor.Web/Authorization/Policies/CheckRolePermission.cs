using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Authorization.Policies
{
    public class CheckRolePermission : IAuthorizationRequirement
    {
        public CheckRolePermission(string permissionLevel)
        {
            PermissionLevel = permissionLevel;
        }

        public string PermissionLevel { get; }
    }
}
