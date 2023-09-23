using AprajitaRetails.Server.Areas.Identity.Pages.Account;
using AprajitaRetails.Server.Models;
using AprajitaRetails.Shared.Models.Auth;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

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

        [HttpGet]
        public async Task<ActionResult<ApplicationUser?>> GetUser(string userid)
        {
            var user = _userManager.Users.First(c => c.UserName == userid);
            if (user != null) return user; else return NotFound();
        }

        [HttpPost("customlogout")]
        public async Task<ActionResult<bool>> PostLogout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return Ok(true);
        }

        [HttpPost("autoLogin")]
        public async Task<ActionResult<string>> PostAutoLogin()
        {
            var result = await _signInManager.PasswordSignInAsync("AmitKumar", "Dumka@1234", true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                //var xName = _userManager.Users.First(c => c.UserName == login.UserName).FullName;
                _logger.LogInformation("User logged in.");
                var user = _userManager.Users.First(c => c.UserName == "AmitKumar");
                var logged = new LoggedUser
                {
                    EmployeeId = user.EmployeeId,
                    FullName = "Amit Kumar",
                    StoreId = user.StoreId,
                    Id = "AmitKumar",
                    StoreGroupId = "",
                    AppClinetId = "",
                    Permission = RolePermission.Owner,
                    UserType = UserType.Admin
                };
                _logger.LogInformation("User logged in.");
                return Ok(logged);
            }
            return Problem("Not able login");
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostLogin(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {

                    var user = _userManager.Users.First(c => c.UserName == login.UserName);

                    if (!user.Approved)
                    {
                        return Problem("User account is not approved for operations. Kindly contact Admin for futher operations!");
                    }

                    var logged = new LoggedUser
                    {
                        EmployeeId = user.EmployeeId,
                        FullName = login.UserName,
                        StoreId = user.StoreId,
                        Id = user.UserName


                     StoreGroupId = user.StoreGroupId,
                        AppClinetId = user.AppClinetId,
                        Permission = user.Permission,
                        UserType = user.UserType

                    };
                    _logger.LogInformation("User logged in.");
                    return Ok(logged);
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

        [HttpPost("register")]
        public async Task<ActionResult<bool>> PostRegisterNewUser(RegisterUserVM newUser)
        {
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, newUser.UserName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, newUser.Email, CancellationToken.None);

                if (!string.IsNullOrEmpty(newUser.FullName)) user.FullName = newUser.FullName;
                if (!string.IsNullOrEmpty(newUser.StoreId)) user.StoreId = newUser.StoreId;
                if (!string.IsNullOrEmpty(newUser.EmployeeId)) user.EmployeeId = newUser.EmployeeId;

                if (!string.IsNullOrEmpty(newUser.StoreGroupId)) user.StoreGroupId = newUser.StoreGroupId;
                if (!string.IsNullOrEmpty(newUser.AppClinetId)) user.AppClinetId = newUser.AppClinetId;
                if (newUser.Premission != null) user.Premission = newUser.Premission;

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
        [HttpPost("changepassword")]
        public async Task<ActionResult<bool>> PostChangePassword(NewPassowrd Input)
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Id, Input.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    user = _userManager.Users.First(c => c.UserName == Input.Id);

                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.Password, Input.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    string err = "";
                    foreach (var error in changePasswordResult.Errors)
                    {
                        err += $"#{error.Description} ";
                    }
                    return Problem(err);
                }

                await _signInManager.RefreshSignInAsync(user);
                _logger.LogInformation("User changed their password successfully.");


                return Ok("Password is changed");
            }
            return Problem("Failed to validate user");
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