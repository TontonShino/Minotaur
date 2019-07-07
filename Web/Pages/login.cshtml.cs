using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Web.Pages
{
    public class loginModel : PageModel
    {

        readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<LoginModel> _logger;

        public loginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            this._logger = logger;
            this.signInManager = signInManager;
        }

        
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; } 

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; } = true;
        }

        public IActionResult OnGet()
        {
            if(signInManager.IsSignedIn(User))
            {
                return Redirect("/");
            }
            Input = new InputModel();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
           
            
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return Redirect("/");
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("Post effectué");
            return Page();
        }
    }
}