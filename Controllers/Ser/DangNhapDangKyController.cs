using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAn003.Models;

namespace DoAn003.Controllers.Ser
{
    public class DangNhapDangKyController : Controller
    {
        // GET: DangNhapDangKy
        WebCayCanhDB data = new WebCayCanhDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap(string tentk, string mk)
        {
            var ad = data.NhanVien.SingleOrDefault(n=>n.TenDangNhap==tentk&&n.MatKhau==mk);
            if (ad != null)
            {
                Session["admin"] = ad;
                Session["AnhAd"] = ad.Anh;
                Session["TenAd"] = ad.HoTen;
                return Redirect("~/QuanLySanPham/quanlysanpham");
            }
            else return Redirect("~/DangNhapDangKy/KhungDnDk");
        }
        public ActionResult KhungDnDk()
        {
            return View();
        }
    }
}