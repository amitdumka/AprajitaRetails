using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AprajitaRetails.Server.Areas.Identity.Pages.Account;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Models;
using AprajitaRetails.Shared.Models.Auth;
using AprajitaRetails.Shared.Models.Vouchers;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AprajitaRetails.Server.Controllers.Auths
{
    [Route("[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        //private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public AuthsController(UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            IEmailSender emailSender)
        {

            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;
        }

        [HttpPost("customlogout")]
        public async Task<ActionResult<bool>> PostLogout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return Ok(true);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> PostLogin(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return Ok(true);
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return Problem("User account locked out");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Problem("Invalid login attempt.");

                }
            }
            else return Problem("parameter is not valid!");
        }

        [HttpPost("customregister")]
        public async Task<ActionResult<bool>> PostRegisterNewUser(RegisterUserVM newUser)
        {
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, newUser.UserName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, newUser.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, newUser.Password);

                if (result.Succeeded)
                {
                    return Ok(await ProcessNewUserAsync(user));
                }
                string errormsg = "";
                foreach (var error in result.Errors)
                {
                    errormsg += (error.Description + "\n");
                }
                return Problem(errormsg);
            }
            return Problem("Model is not valid!");
        }
        private ApplicationUser CreateUser()
        {
            try
            {

                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
        private async Task<bool> ConfirmEmailAsync(ApplicationUser user, string code)
        {
            //code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return result.Succeeded ? true : false;
        }

        private async Task<bool> ProcessNewUserAsync(ApplicationUser user)
        {
            _logger.LogInformation("User created a new account with password.");

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                var result = await _userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                    await _signInManager.SignInAsync(user, isPersistent: false);
                return result.Succeeded ? true : false;
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;

            }
        }
    }
    
}

