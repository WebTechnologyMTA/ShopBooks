using ShopBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBooks.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ModelDbContext db = new ModelDbContext();

        public ActionResult QLHD()
        {
            return View(db.DonHangs);
        }
    }
}