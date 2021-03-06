using Narendra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narendra.Controllers
{
    public class AdminController : Controller
    {
        private StoreContext _con;

        // GET: Account
        public AdminController()
        {
            _con = new StoreContext();
        }

        public ActionResult AdminRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegistration(Register aregister)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminRegistration", aregister);
            }

            if (_con.Registers.Where(u => u.Email == aregister.Email).Any())
            {
                ModelState.AddModelError("Email", "This Email is already exists.");
                return View("AdminRegistration", aregister);
            }

            if (_con.Registers.Where(u => u.Username == aregister.Username).Any())
            {
                ModelState.AddModelError("Username", "This Username is already exists.");
                return View("AdminRegistration", aregister);
            }
            _con.Registers.Add(aregister);
            _con.SaveChanges();
            return Content("your registration is completed successfully,please Login");
        }
        // GET: Admin
        public ActionResult SuccessAdmin()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Contact()
        {
            return View();

        }
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult InvigilatorRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InvigilatorRegistration(Register bregister)
        {
            if (!ModelState.IsValid)
            {
                return View("InvigilatorRegistration", bregister);
            }

            if (_con.Registers.Where(u => u.Email == bregister.Email).Any())
            {
                ModelState.AddModelError("Email", "This Email is already exists.");
                return View("InvigilatorRegistration", bregister);
            }

            if (_con.Registers.Where(u => u.Username == bregister.Username).Any())
            {
                ModelState.AddModelError("Username", "This Username is already exists.");
                return View("InvigilatorRegistration", bregister);
            }
            _con.Registers.Add(bregister);
            _con.SaveChanges();
            return Content("your registration is completed successfully,please Login");
        }
    }
}