using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBooks.Models;

namespace ShopBooks.Controllers
{
    public class ProductController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Product
        public ActionResult Category(int ID)
        {
            var chude = db.ChuDes.Where(x => x.MaChuDe == ID);
            return View(chude);
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