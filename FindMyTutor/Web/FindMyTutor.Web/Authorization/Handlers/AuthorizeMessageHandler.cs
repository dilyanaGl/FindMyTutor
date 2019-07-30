using FindMyTutor.Web.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Web.Helpers;

namespace FindMyTutor.Web.Authorization.Handlers
{
    public class AuthorizeMessageHandler : AuthorizationHandler<Policies.MessageRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizeMessageHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MessageRequirement requirement)
        {
            string path = httpContextAccessor.HttpContext.Request.Path;
            int lastIndex = path.LastIndexOf('/');
            var resourceId = path.Substring(lastIndex + 1);

            if (httpContextAccessor.HttpContext.User.HasClaim(
                p => p.Type == Constants.Policy.MessageType && p.Value == resourceId))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}
