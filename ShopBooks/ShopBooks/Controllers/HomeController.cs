using ShopBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBooks.Controllers
{
    public class HomeController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Home
        public ActionResult Index()
        {
            List<Sach> ls = new List<Sach>();
            var ListProduct = db.Saches.Take(10);
            foreach (var item in ListProduct)
            {
                item.AnhBia = "/Content/assets/product_img/" + item.AnhBia;
                ls.Add(item);
            }
            return View(ls);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult PartialMenuList()
        {
            List<ChuDe> ls = new List<ChuDe>();
            foreach (var item in db.ChuDes)
            {
                ls.Add(item);
            }
            return PartialView("_PartialMenuList", ls);
        }
    }
}