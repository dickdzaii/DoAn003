using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models.ListEntities;
using DoAn003.Models;
namespace DoAn003.Controllers
{
    public class QuanLyLoaiController : Controller
    {
        WebCayCanhDB db = new WebCayCanhDB();
        // GET: QuanTri
        SanPhamModel qlsp = new SanPhamModel();
        LoaiSanPhamModel qllsp = new LoaiSanPhamModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        //quản lý loại sp
        public ActionResult quanlyloaisanpham()
        {
            List<LoaiSanPham> dslsp = qllsp.DanhSachLoai();
            return View(dslsp);
        }
        public ActionResult laymotloai(string id)
        {
            var loaicanlay = qllsp.Get1Loai(id);
            return Json(loaicanlay, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoamotloai(string id)
        {
            qllsp.XoaMotLoai(id);
            return Redirect("~/QuanLyLoai/quanlyloaisanpham");
        }
        public ActionResult themvasualoai(string tenloai, string mota, string aoe)
        {
            List<LoaiSanPham> dslsp = qllsp.DanhSachLoai();
            LoaiSanPham loaisp = new LoaiSanPham();
            loaisp.MaLoai = "LSP"+(db.LoaiSanPham.Count() + 1).ToString();
            loaisp.TenLoai = tenloai;
            loaisp.MoTa = mota;

            if (aoe == "1")
            {
                qllsp.ThemMotLoai(loaisp);
            }
            else
            {
                qllsp.CapNhatMotLoai(loaisp);
            }
            return Redirect("~/QuanLyLoai/quanlyloaisanpham");
        }
    }
}