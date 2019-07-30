using FindMyTutor.Web.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Authorization.Handlers
{
    public class MustNotBeLoggedInHandler : AuthorizationHandler<MustNotBeLoggedIn>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MustNotBeLoggedIn requirement)
        {
            if(context.User.Identity.IsAuthenticated)
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
