using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
namespace DoAn003.Controllers.Ser
{
    public class QuanLyChiTietHoaDonNhapController : Controller
    {
        // GET: QuanLyChiTietHoaDonNhap
        ChiTietHoaDonNhapModel qlct = new ChiTietHoaDonNhapModel();
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult quanlycthdn()
        {
            List<ChiTietHoaDonNhap> dsct = qlct.DanhSachChiTiethoaDonNhap();
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
            return Redirect("~/QuanLyChiTietHoaDonNhap/quanlycthdn");
        }

        public ActionResult themvasuact(string mact,string mahdn,string masp, string tensp,  int solg, int gianhap, int thanhtien,  string aoe)
        {
            List<ChiTietHoaDonNhap> dslsp = qlct.DanhSachChiTiethoaDonNhap();
            ChiTietHoaDonNhap ct = new ChiTietHoaDonNhap();
            ct.MaChiTiet = mact;
            ct.MaHoaDonNhap = mahdn;
            ct.MaSanPham = masp;
            ct.TenSanPham = tensp;
            ct.SoLuong = solg;
            ct.GiaNhap = gianhap;
            ct.ThanhTien = thanhtien;
            if (aoe == "1")
            {
                qlct.ThemMotCT(ct);
            }
            else
            {
                qlct.CapNhatMotCT(ct);
            }
            return Redirect("~/QuanLyChiTietHoaDonNhap/quanlycthdn");
        }
    }
}