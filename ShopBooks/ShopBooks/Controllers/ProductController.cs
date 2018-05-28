using ShopBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBooks.Controllers
{
    public class ProductController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Product
        public ActionResult ProductDetails(int id)
        {
            return View(db.Saches.Where(x => x.MaSach == id));
        }
        public ActionResult ListBook()
        {

            return PartialView();
        }

    }
}