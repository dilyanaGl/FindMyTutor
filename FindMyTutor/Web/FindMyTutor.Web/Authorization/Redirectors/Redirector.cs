using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Authorization.Redirectors
{

    public class Redirector
    {
        private Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(object forbidden, Func<RedirectContext<CookieAuthenticationOptions>, Task> onRedirectToAccessDenied)
        {
            throw new NotImplementedException();
        }
    }
}
