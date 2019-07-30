using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindMyTutor.Data.Models;
using System.Text;
using Microsoft.AspNetCore.Identity;
using FindMyTutor.Web.Helpers;

namespace FindMyTutor.Web.Areas.Identity.Pages.Account.Controllers
{
    using FindMyTutor.Web.Areas.Identity.Account.Models;
    using Microsoft.AspNetCore.Authorization;
    using Models;

    //[Area("Identity")]
    ////   [Authorize(Policy ="MustNotBeLoggedIn")]
    //[Route("/Identity/Account/")]
    //public class AccountController : Controller
    //{
    //    private readonly UserManager<FindMyTutorUser> userManager;
    //    private readonly SignInManager<FindMyTutorUser> signInManager;
    //    private readonly RoleManager<IdentityRole> roleManager;

    //    public AccountController(UserManager<FindMyTutorUser> userManager, SignInManager<FindMyTutorUser> signInManager, RoleManager<IdentityRole> roleManager)
    //    {
    //        this.userManager = userManager;
    //        this.signInManager = signInManager;
    //        this.roleManager = roleManager;
    //    }

    //    [HttpGet]
    //    [Route("/Identity/Account/Register")]
    //    public IActionResult Register()
    //    {
    //        // _Areas_Identity_Pages_Account_Register;

    //        return this.View();
    //        //   return this.View();
    //    }

    //    [Route("/Identity/Account/Register")]
    //    [HttpPost]
    //    public async Task<IActionResult> Register(RegisterViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new FindMyTutorUser
    //            {
    //                UserName = model.Username,
    //                PasswordHash = Utilities.HashPassword(model.Password),
    //                Email = model.Email,

    //            };

    //            var usernameExists = await userManager.FindByNameAsync(model.Username);
    //            if (usernameExists != null)
    //            {
    //                this.ViewData["Error"] = "Вече съществува потребител с това име!";
    //                return await Task.Run(() => this.Register());
    //            }            
               

    //            var result = await userManager.CreateAsync(user);

    //            if (model.IsTutor)
    //            {
    //                await userManager.AddClaimAsync(user,
    //                    new System.Security.Claims.Claim("Role", "Tutor"));
    //            }
               
    //             await signInManager.SignInAsync(user, false);
                  
    //             return await Task.Run(() => this.Redirect("/"));           

    //        }
    //        else
    //        {
    //            //var errorMessages = new StringBuilder();

    //            //foreach (var message in ModelState.Values.SelectMany(p => p.Errors).Select(p => p.ErrorMessage))
    //            //{
    //            //      errorMessages.AppendLine(message);
    //            //}

    //            //this.ViewData["ErrorMessage"] = errorMessages.ToString().Trim();
    //            return await Task.Run(() => this.Register());
    //        }



    //    }


    //}
}