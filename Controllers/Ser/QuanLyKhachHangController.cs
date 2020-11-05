using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
namespace DoAn003.Controllers.Ser
{
    public class QuanLyKhachHangController : Controller
    {
        // GET: QuanLyKhachHang
        KhachHangModel qlkh = new KhachHangModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuanLyKH()
        {
            List<KhachHang> dshdn = qlkh.DanhSachKhachHang();
            return View(dshdn);
        }
        public ActionResult laymotkh(string id)
        {
            var hdn = qlkh.Get1KH(id);
            return Json(hdn, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoamotkh(string id)
        {
            qlkh.XoaMotKH(id);
            return Redirect("~/QuanLyKhachHang/QuanLyKH");
        }
        public ActionResult themvasuakh(string makh,string hoten, string diachi,string sdt,string email,string gt, DateTime ngaysinh, string mk, string aoe)
        {
            List<KhachHang> dslsp = qlkh.DanhSachKhachHang();
            KhachHang cst = new KhachHang();
            cst.MaKhachHang = makh;
            cst.HoTen = hoten;
            cst.DiaChi = diachi;
            cst.SoDienThoai = sdt;
            cst.Email =email;
            cst.GioiTinh =gt; 
            cst.NgaySinh = ngaysinh;
            cst.MatKhau = mk;

            if (aoe == "1")
            {
                qlkh.ThemMotKH(cst);
            }
            else
            {
                qlkh.CapNhatMotKH(cst);
            }
            return Redirect("~/QuanLyKhachHang/QuanLyKH");
        }
    }
}