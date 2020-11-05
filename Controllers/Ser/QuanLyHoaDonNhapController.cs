using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
using Newtonsoft.Json;
using PagedList;

namespace DoAn003.Controllers.Ser
{
    public class QuanLyHoaDonNhapController : Controller
    {
        WebCayCanhDB data = new WebCayCanhDB();
        // GET: QuanLyHoaDonNhap
        public ActionResult Index()
        {
            return View();
        }
        HoaDonNhapModel qlgb = new HoaDonNhapModel();
        ChiTietHoaDonNhapModel qlct = new ChiTietHoaDonNhapModel();
        public ActionResult quanlyhdn(int ? page)
        {
            int amount = 10;
            int pagenumber = (page ?? 1);
            return View(data.HoaDonNhap.OrderBy(s=>s.MaHoaDonNhap).ToPagedList(pagenumber,amount));
        }
        public ActionResult laymothdn(string id)
        {
            
            var ct = qlct.LayChiTietTheoHD(id);
            foreach (var dt in ct)
            {
                dt.MaSanPham.ToString();
            }
            return View();
        }
        public ActionResult xoamothdn(string id)
        {
            qlgb.XoaMotHDN(id);
            return Redirect("~/QuanLyHoaDonNhap/quanlyhdn");
        }
        
        public ActionResult themvasuahdn(string mancc, string manv, DateTime ngaynhap, string aoe)
        {
            List<HoaDonNhap> dslsp = qlgb.DanhSachHoaDonNhap();
            HoaDonNhap gia = new HoaDonNhap();
            gia.MaNhaCungCap = mancc;
            gia.MaNhanVien = manv;
            gia.NgayNhap = ngaynhap;
            
            if (aoe == "1")
            {
                qlgb.ThemMotHDN(gia);
            }
            else
            {
                qlgb.CapNhatMotHDN(gia);
                
            }
            return Redirect("~/QuanLyHoaDonNhap/quanlyhdn");
        }
    }
}