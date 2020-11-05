using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
namespace DoAn003.Controllers.Ser
{
    public class QuanLyNhanVienController : Controller
    {
        // GET: QuanLyNhanVien
        NhanVienModel qlnv = new NhanVienModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult quanlynv()
        {
            List<NhanVien> dsnv = qlnv.DanhSachNhanVien();
            return View(dsnv);
        }
        public ActionResult laymotnv(string id)
        {
            var nv = qlnv.Get1NV(id);
            return Json(nv, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoamotnv(string id)
        {
            qlnv.XoaMotNV(id);
            return Redirect("~/QuanLyNhanVien/quanlynv");
        }
        public ActionResult themvasuanv(string hoten, DateTime ngayvao, DateTime ngaythoi, string tdn, string mk, HttpPostedFileBase anh, string aoe)
        {

            NhanVien nv = new NhanVien();
            nv.HoTen = hoten;
            nv.NgayVaoLam = ngayvao;
            nv.NgayThoiViec = ngaythoi;
            nv.TenDangNhap = tdn;
            nv.MatKhau=mk;

            if (anh.ContentLength > 0)//nếu chiều dài bức ảnh>0, bức ảnh đã tồn tại
            {
                string path = Server.MapPath("~Assets/images") + "/" + anh.FileName; //đường dẫn đến ảnh, anh.FileName là tên ảnh
                anh.SaveAs(path);
                nv.Anh = anh.FileName;
            }
            else nv.Anh = null;
            if (aoe == "1")
            {
                qlnv.ThemMotNV(nv);
            }
            else
            {
                qlnv.CapNhatMotNV(nv);
            }
            return Redirect("~/QuanLyNhanVien/quanlynv");
        }

    }
}