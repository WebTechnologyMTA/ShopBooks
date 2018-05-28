using ShopBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBooks.Areas.Admin.Controllers
{
    public class QLDHController : Controller
    {
        // GET: Admin/QLDH
        ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {
            return View(db.DonHangs.ToList());
        }
    }
}