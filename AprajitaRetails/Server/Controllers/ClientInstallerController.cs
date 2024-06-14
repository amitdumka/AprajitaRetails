using AprajitaRetails.Server.Areas.Identity.Pages.Account;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Models;
using AprajitaRetails.Shared.Models.Auth;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AprajitaRetails.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientInstallerController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        private readonly IEmailSender _emailSender;

        private readonly ARDBContext _context;
        private readonly ApplicationDbContext _authDb;

        //Default Constructor
        public ClientInstallerController(UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            IEmailSender emailSender, ARDBContext context, ApplicationDbContext applicationDbContext)
        {

            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;
            _context = context;
            _authDb = applicationDbContext;
        }

        [HttpGet("DefaultClientRegistration")]
        public async Task<ActionResult<RegisteredClient>> GetDefaultClient()
        {
            var info = new ClientInfo
            {
                Name = "Aadwika Fashion",
                Address = "Bhagalpur Road, Near TATA Showroom, Dumka",
                City = "Dumka",
                State = "Jharkhand",
                Country = "India",
                PinCode = "814101",
                Mobile = "9334799099",
                GSTIN = "20AJHPA7396P1ZV",
                PanNo = "AJHPA7396P",
                Email = "aadwikafashion@gmail.com",
                StartDate = new DateTime(2024, 04, 01),
                ContactPersonName = "Alok Kumar",
                ContactPersonMobile = "1234567890",
                OwnerName = "Amit Kumar",
                StoreCode = "MBO",
                BankAccountNumber = "SBI Current",
                BankName = "State Bank If India",
                BranchName = "LIC colony",
                IFSCode = "SBIN001740"


            };

            var client = ClientInstaller.RegisterClient(_context, _authDb, info);

            client = await CreateAdminUsersAsync(info, client);
            return Ok(client);
        }

        public async Task<IActionResult> PostClientRegistration(ClientInfo info)
        {
            if (ModelState.IsValid)
            {
                //Creating  Client 
                //Creating  Admin User and Owner User
                var client = ClientInstaller.RegisterClient(_context, _authDb, info);

                client = await CreateAdminUsersAsync(info, client);
                return Ok(client);

            }
            return BadRequest();
        }

        //Creating Admin and Owner User. 
        private async Task<RegisteredClient> CreateAdminUsersAsync(ClientInfo info, RegisteredClient client)
        {

            // Creating Default Admin Account.

            bool userCreated = false;
            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, client.RegisterAdminUserName, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, info.Email, CancellationToken.None);

            user.FullName = "Admin User";
            user.StoreId = client.Stores[0].StoreId??"MBO";
            user.EmployeeId = client.Owner.EmployeeId;

            user.StoreGroupId = client.Groups[0].StoreGroupId;
            user.Approved = true;
            user.Permission = RolePermission.Owner;

            var result = await _userManager.CreateAsync(user, client.DefaultPassword);
            if (result.Succeeded)
            {
                //Do Conirmation here
                _logger.LogInformation("User created a new account with password.");
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    var result2 = await _userManager.ConfirmEmailAsync(user, code);
                    if (result2.Succeeded)
                        userCreated = true;
                }
                else
                {
                    userCreated = true;
                }
                client.Remarks += $"#Admin User Created[U:{user.UserName}, P:{client.DefaultPassword}];";

            }


            //Creating Default Owner Account.
            if (userCreated)
            {

                user = CreateUser();



                await _userStore.SetUserNameAsync(user, info.OwnerName.Split(' ')[0], CancellationToken.None);
                await _emailStore.SetEmailAsync(user, info.Email, CancellationToken.None);
                user.FullName = info.OwnerName;
                user.StoreId = info.StoreCode??"MBO";
                user.EmployeeId = client.Owner.EmployeeId;

                user.StoreGroupId = info.StoreCode;




                user.Approved = true;
                user.Permission = RolePermission.Owner;



                result = await _userManager.CreateAsync(user, client.DefaultOwnerPassword);

                if (result.Succeeded)
                {
                    //Do Conirmation here
                    _logger.LogInformation("User created a new account with password.");
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        var result3 = await _userManager.ConfirmEmailAsync(user, code);
                        if (result3.Succeeded)
                            userCreated = true;
                    }
                    else
                    {
                        userCreated = true;
                    }
                    client.Remarks += $"#Owner User Created[U:{user.UserName}, P:{client.DefaultOwnerPassword}];";
                }



            }
            return client;
        }
        //Copied from Auth Controller
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

    }//End of class
}//end of namespace