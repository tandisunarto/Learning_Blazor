﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BethanysPieShopHRM.Server.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        // private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(
            // SignInManager<IdentityUser> signInManager, 
            ILogger<LogoutModel> logger)
        {
            // _signInManager = signInManager;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            // if (returnUrl != null)
            // {
            //     return LocalRedirect(returnUrl);
            // }
            // else
            // {
            //     return RedirectToPage();
            // }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            // await _signInManager.SignOutAsync();
            // _logger.LogInformation("User logged out.");
            // if (returnUrl != null)
            // {
            //     return LocalRedirect(returnUrl);
            // }
            // else
            // {
            //     return RedirectToPage();
            // }
            return RedirectToPage();
        }
    }
}
