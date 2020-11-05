using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;

namespace DoAn003.Controllers.Ser
{
    public class QuanLyChiTietDonHangController : Controller
    {
        // GET: QuanLyChiTietDonHang
        ChiTietDonHangModel qlct = new ChiTietDonHangModel();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult quanlycthdn()
        {
            List<ChiTietDonHang> dsct = qlct.DanhSachChiTietDonHang();
            return View(dsct);
        }
        public ActionResult laymotct(string id)
        {
            var cthdn = qlct.Get1CT(id);
            return Json(cthdn, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoamotct(string id)
        {
            qlct.XoaMotCT(id);
            return Redirect("~/QuanLyChiTietDonHang/quanlycthdn");
        }
        public ActionResult themvasuact(string mact, string madh, string masp,string tensp,string anh, int solg, int dongia, int thanhtien, string aoe)
        {
            List<ChiTietDonHang> dslsp = qlct.DanhSachChiTietDonHang();
            ChiTietDonHang ct = new ChiTietDonHang();
            ct.MaChiTiet = mact;
            ct.MaDonHang= madh;
            ct.MaSanPham = masp;
            ct.TenSanPham = tensp;
            ct.Anh = anh;
            ct.SoLuong = solg;
            ct.DonGia = dongia;
            ct.ThanhTien = thanhtien;
            if (aoe == "1")
            {
                qlct.ThemMotCT(ct);
            }
            else
            {
                qlct.CapNhatMotCT(ct);
            }
            return Redirect("~/QuanLyChiTietDonHang/quanlycthdn");
        }
    }
}