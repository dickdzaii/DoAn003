using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
namespace DoAn003.Controllers.Ser
{
    public class QuanLyDonHangController : Controller
    {
        // GET: QuanLyDonHang
        DonHangModel qldh = new DonHangModel();
        ChiTietDonHangModel qlct = new ChiTietDonHangModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuanLyDH()
        {
            List<DonHang> dsdh = qldh.DanhSachDonHang();
            return View(dsdh);
        }
        public ActionResult laymotdh(string id)
        {
            var dh = qlct.LayCTTheoDonHang(id);
            return View(dh);
        }
        public ActionResult xoamotdh(string id)
        {
            qldh.XoaMotDonHang(id);
            return Redirect("~/QuanLyDonHang/QuanLyDH");
        }
        public ActionResult themvasuadh(string madh, string makh, DateTime ngaydathang, string trangthai, string aoe)
        {
            List<DonHang> dsdh = qldh.DanhSachDonHang();
            DonHang cst = new DonHang();
            cst.MaDonHang = madh;
            cst.MaKhachHang = makh;
            cst.NgayDatHang = ngaydathang;
            cst.TrangThai = trangthai;

            if (aoe == "1")
            {
                qldh.ThemMotDonHang(cst);
            }
            else
            {
                qldh.ThemMotDonHang(cst);
            }
            return Redirect("~/QuanLyDonHang/QuanLyDH");
        }
    }
}