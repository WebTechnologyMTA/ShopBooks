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
            var ListProduct = db.Saches.Take(3);
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
        // GET: Chu De
        public PartialViewResult PartialMenuList()
        {
            List<ChuDe> ls = new List<ChuDe>();
            foreach (var item in db.ChuDes)
            {
                ls.Add(item);
            }
            return PartialView("_PartialMenuList", ls);
        }

        // GET: Category/ID
        public ActionResult Category(int ID)
        {
            List<Sach> ls = db.Saches.Where(x => x.MaChuDe == ID).ToList();
            foreach(var item in ls)
            {
                item.AnhBia = "/Content/assets/product_img/" + item.AnhBia;
            }
            return View(ls);
        }

        // GET: ProductDetail/ID
        public ActionResult ProductDetail(int ID)
        {
            var sach = db.Saches.Where(x => x.MaSach == ID).SingleOrDefault();
            sach.AnhBia = "/Content/assets/product_img/" + sach.AnhBia;
            sach.NhaXuatBan = db.NhaXuatBans.Where(x => x.MaNXB == sach.MaNXB).SingleOrDefault();
            return View(sach);
        }
    }
}