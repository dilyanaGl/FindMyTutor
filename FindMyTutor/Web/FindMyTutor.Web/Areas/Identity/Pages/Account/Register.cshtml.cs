using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FindMyTutor.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<FindMyTutorUser> _signInManager;
        private readonly UserManager<FindMyTutorUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;


        public RegisterModel(
            UserManager<FindMyTutorUser> userManager,
            SignInManager<FindMyTutorUser> signInManager,
            ILogger<RegisterModel> logger
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Полето е задължително")]
            [MinLength(3, ErrorMessage = "Потребителското име трябва да бъде дълго поне 3 символа")]
            [Display(Name = "Потрбителско име")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Полето е задължително")]
            [MinLength(3, ErrorMessage = "Името трябва да бъде дълго поне 3 символа")]
            [Display(Name = "Име")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Полето е задължително")]
            [EmailAddress(ErrorMessage = "Невалиден имейл адрес")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Полето е задължително")]
            [MinLength(6, ErrorMessage = "Паролата трябва да бъде дълга поне 6 символа")]
            [Display(Name = "Парола")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Полето е задължително")]
            [Compare("Password", ErrorMessage = "Паролите не съответстват")]
            [Display(Name = "Повторете паролата")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }


            public bool IsTutor { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new FindMyTutorUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    if (Input.IsTutor)
                    {
                        var addClaim = await _userManager.AddClaimAsync(user,
                                                                  new System.Security.Claims.Claim("Role", "Tutor"));

                        if (addClaim.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    else
                    {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                    }



                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
