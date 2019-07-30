using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Web.Helpers;

namespace FindMyTutor.Web.Authorization.Handlers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Policies;
    public class CheckRolePermissionHandler : AuthorizationHandler<Policies.CheckRolePermission>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CheckRolePermissionHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            CheckRolePermission requirement)
        {
            string path = httpContextAccessor.HttpContext.Request.Path;
            int lastIndex = path.LastIndexOf('/');
            var resourceId = path.Substring(lastIndex + 1);
            bool isValid = context.User.IsInRole(Constants.Role.Admin) ||
                context.User.Claims.Any(p => p.Type == requirement.PermissionLevel
            && p.Value == resourceId);
            if (isValid)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
