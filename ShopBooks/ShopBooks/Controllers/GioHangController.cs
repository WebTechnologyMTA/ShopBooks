using ShopBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBooks.Controllers
{
    public class GioHangController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        #region GioHang
        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            // Nếu giỏ hàng null thì khởi tạo giỏ hàng mới
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session GioHang
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sản phẩm đã tồn tại trong giỏ hàng hay chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMaSach == iMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                //Add sản phẩm mới vào giỏ hàng
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                // Tăng số lượng nếu sản phẩm đã tồn tại
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }


        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int iMaSach, FormCollection f, string strURL)
        {
            // Get sản phẩm
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            // Neu get sai masp thi tra ve loi 404 con neu dung thi cap nhat lai gio hang
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lay gio hang ra tu session
            List<GioHang> lstGioHang = LayGioHang();
            // Kiem tra sp co ton tai trong session["GioHang"] 
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSach);
            // Neu ton tai cho phep sua so luong
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["appendedInputButtons"].ToString());
            }
            return Redirect(strURL);
        }

        // Xoa gio hang
        public ActionResult XoaGioHang(int iMaSP)
        {
            // Kiem tra masp
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            // Neu get sai masp thi tra ve loi 404 con neu dung thi cap nhat lai gio hang
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lay gio hang ra tu session
            List<GioHang> lstGioHang = LayGioHang();
            // Kiem tra sp co ton tai trong session["GioHang"] 
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            // Neu ton tai cho phep sua so luong
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSach == iMaSP);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        //Xay dung trang gio hang
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng sản phẩm
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }

        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        //xây d?ng 1 view cho ngu?i dùng s?a gi? hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        //Thêm giỏ hàng
        public ActionResult BotGioHang(int iMaSach, string strURL)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy ra sessionGioHang
            List<GioHang> lstGioHang = LayGioHang();
            // Kiểm tra sản phẩm có trong giỏ hàng
            GioHang sanpham = lstGioHang.Find(n => n.iMaSach == iMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                // Thêm mới
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong--;
                return Redirect(strURL);
            }
        }


        public ActionResult SuaGioHang(int iMaSach, string strURL, int soluong, FormCollection f)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy ra sessionGioHang
            List<GioHang> lstGioHang = LayGioHang();
            // Kiểm tra sản phẩm có trong giỏ hàng
            GioHang sanpham = lstGioHang.Find(n => n.iMaSach == iMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                // Thêm mới sản phẩm vào giỏ hàng
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {

                soluong = int.Parse(f["appendedInputButtons"].ToString());
                sanpham.iSoLuong = sanpham.iSoLuong + soluong;
                return Redirect(strURL);
            }
        }
        #endregion

        #region DatHang
        //Xây d?ng ch?c nang d?t hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Ki?m tra dang nh?p
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm don hàng
            DonHang ddh = new DonHang();
            List<GioHang> gh = LayGioHang();
            ddh.NgayDat = DateTime.Now;
            db.DonHangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi ti?t don hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaSach = item.iMaSach;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (decimal)item.dDonGia;
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();
            return View();
        }
        #endregion

    }
}
