using Narendra.Models;
using Narendra.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace Narendra.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext _context;

        // GET: Account
        public AccountController()
        {
            _context = new StoreContext();
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", register);
            }

            if (_context.Registers.Where(u => u.Email == register.Email).Any())
            {
                ModelState.AddModelError("Email", "This Email is already exists.");
                return View("Registration", register);
            }

            if (_context.Registers.Where(u => u.Username == register.Username).Any())
            {
                ModelState.AddModelError("Username", "This Username is already exists.");
                return View("Registration", register);
            }
            _context.Registers.Add(register);
            _context.SaveChanges();
            return Content("your registration is completed successfully,please Login");
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);


            var loginUser = _context.Registers.Where(u => u.Username == user.Username && u.Password == user.Password && u.IsActive == true && u.Admin == null && u.Invigiltor == null).FirstOrDefault();

            if (loginUser == null)
            {
                var loginAdmin = _context.Registers.Where(u => u.Username == user.Username && u.Password == user.Password && u.IsActive == true && u.Admin != null && u.Invigiltor == null).FirstOrDefault();
                
                if (loginAdmin == null)
                {
                    var loginInvigilator = _context.Registers.Where(u => u.Username == user.Username && u.Password == user.Password && u.IsActive == true && u.Admin == null && u.Invigiltor!= null).FirstOrDefault();

                    if (loginInvigilator == null)
                    {

                        ModelState.AddModelError("Username", "username or password is wrong ,Please try with new username or password");
                        return View("Login");
                    }

                    else 
                    {
                        Session["Invigiltor"] = loginInvigilator.Invigiltor;
                        return RedirectToAction("SuccessInvigilator", "Account");
                    }
                    

                }
                else
                {
                        Session["Admin"] =loginAdmin.Admin;
                        return RedirectToAction("SuccessAdmin", "Admin");
                }
                   

            }
            else
            {
                Session["Username"] = loginUser.Username;
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult Contact()
        {
            var information = _context.Registers.ToList();
            
            ViewBag.Registers = information;
            return View();

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

       

       

    }
}