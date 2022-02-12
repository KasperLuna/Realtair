using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return Redirect("/Accounts/Login");
        }

        public ActionResult Landing()
        {
            if (Session["Username"] != null)
            {
                return View();
            } else
            {
                return Redirect("/Accounts/Login");
            }
            
        }

        // GET: Accounts/Register
        public ActionResult Register()
        {
            ViewBag.Message = (TempData["Message"] != null ? TempData["Message"].ToString() : "");
            if (Session["Username"] != null)
            {
                return Redirect("/Accounts/Landing");
            }
            else
            {
                return View();
            }
        }

        // GET: Accounts/Login
        public ActionResult Login()
        {
            ViewBag.Message = (TempData["Message"] != null ? TempData["Message"].ToString() : "") ;
            if (Session["Username"] != null)
            {
                return Redirect("/Accounts/Landing");
            }
            else
            {
                return View();
            }
        }

        // POST: Accounts/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Email,FName,LName,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AccountContext())
                {
                    var obj = db.Accounts.Where(a => a.Email.Equals(account.Email)).FirstOrDefault();
                    if (obj != null)
                    {
                        TempData["Message"] = "Account with provided email already exists.";
                        return Redirect("/Accounts/Register");
                    }
                    else
                    {
                        db.Accounts.Add(account);
                        db.SaveChanges();
                        Session["Username"] = account.FName;
                        return Redirect("/Accounts/Landing");
                    }
                }
            }
            else
            {
                TempData["Message"] = "Provided information is invalid, Please try again.";
                return Redirect("/Accounts/Login");
            }
        }

        // POST: Accounts/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AccountContext())
                {
                    var obj = db.Accounts.Where(a => a.Email.Equals(account.Email) && a.Password.Equals(account.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Username"] = obj.FName.ToString();
                        return Redirect("/Accounts/Landing");
                    }
                    else
                    {
                        TempData["Message"] = "Account credentials provided are invalid, try again.";
                        return Redirect("/Accounts/Login");
                    }
                }
            }
            else
            {
                TempData["Message"] = "Account credentials provided are invalid, try again.";
                return Redirect("/Accounts/Login");
            }
        }

        //GET: Accounts/Logout
        public ActionResult Logout()
        {
            Session["Username"] = null;
            return Redirect("/");
        }
    }
}
