using PagedList;
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
        
        public ActionResult Index(int? page)
        {
            //@model IEnumerable<ShopBooks.Models.Sach>
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(db.Saches.Where(n =>n.Moi==1).OrderBy(n=>n.GiaBan).ToPagedList(pageNumber,pageSize));
        }
      
     
        public ActionResult ListBook()
        {
            return View(db.Saches);
        }
       

        [HttpPost]
        public ActionResult Search(string name)
        {
            var task= from t in db.Saches select t;

            if (name == null)
            {
                ViewBag.Message = "Khong co sach nao phu hop";
            }

            else
            {
                task = task.Where(x => x.TenSach.Contains(name));
            }
                return View(task);
        }
        public ActionResult CategoryBook(int macate)
        {
            return View(db.Saches.Where(x => x.MaChuDe == macate));
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