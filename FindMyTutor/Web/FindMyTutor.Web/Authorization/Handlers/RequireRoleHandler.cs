using FindMyTutor.Web.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Web.Helpers;

namespace FindMyTutor.Web.Authorization.Handlers
{
    public class RequireRoleHandler : AuthorizationHandler<RequireRole>
    {
        
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireRole requirement)
        {
            var claims = context.User.Claims;
           bool isValid = context.User
                .Claims.Any(p => p.Type == Constants.Policy.RoleType 
                && p.Value == requirement.Role);

            if (isValid)
            {
               context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
