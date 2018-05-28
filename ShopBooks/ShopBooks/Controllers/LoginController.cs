using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBooks.Models;

namespace ShopBooks.Controllers
{
    public class LoginController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //  HttpPost Index
        [HttpPost]
        public ActionResult Index(UserAccount user)
        {
            if(!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                var result = db.UserAccounts.Where(x => x.Email == user.Email && x.Password == user.Password).Single();
                if (result != null && result.IsAdmin == true)
                    return RedirectToAction("Preview", "SachManager", new { area = "Admin" });
                if (result != null)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                db.UserAccounts.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}