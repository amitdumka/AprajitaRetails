using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AprajitaRetails.Server.Controllers.Auths
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthHelperController : Controller
    {



        private readonly ARDBContext _context;
        private readonly ApplicationDbContext _authDb;

        public AuthHelperController(ARDBContext context, ApplicationDbContext applicationDbContext)
        {
            _context = context;
            _authDb = applicationDbContext;
        }


        [HttpGet("UpdateGroupId")]
        public async Task<ActionResult<bool?>> GetUpdateUser()
        {
            var list=_authDb.Users.ToList();
            foreach (var item in list)
            {
                item.Approved = true; item.StoreGroupId = "TAS";
                item.AppClinetId = Guid.Parse( "a765c480-25c8-440b-9fc4-047e4a66834f");
                _authDb.Users.Update(item);
                if (item.UserName == "AmitKumar") { item.UserType = UserType.SuperAdmin; item.Permission = RolePermission.Owner; }

                else
                {
                    item.UserType = UserType.PowerUser; item.Permission = RolePermission.StoreManager;
                    
                }
            }
            return _authDb.SaveChanges()>0;
        }

        [HttpGet("UpdateBankAccount")]
        public async Task<ActionResult<bool?>> GetBankAccount()
        {
            var list = _context.BankAccounts.ToList();
            foreach (var item in list)
            {
                item.AppClientId = Guid.Parse("a765c480-25c8-440b-9fc4-047e4a66834f");
                item.StoreGroupId = "TAS";
               
            }
            return _context.SaveChanges() > 0;
        }
        // GET: AuthHelperController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthHelperController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthHelperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthHelperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthHelperController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthHelperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthHelperController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthHelperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
