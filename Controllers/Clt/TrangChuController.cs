using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
using PagedList;
using PagedList.Mvc;

namespace DoAn003.Controllers.Clt
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        WebCayCanhDB data = new WebCayCanhDB();
        SanPhamModel spmodel = new SanPhamModel();
        public ActionResult Index()
        {
            Response.StatusCode = 404;
            return null;
        }
        public ActionResult Home()
        {
            
            data.SanPham.Take(10).OrderBy(n=>n.MaSanPham).ToList();
            return View();
        }
        public ActionResult SanPham(int? page)
        {
            int pageSite = 8;

            int pageNumber = (page ?? 1);
                List<SanPham> dssp = spmodel.DanhSachSanPham();
                return View(dssp.ToPagedList(pageNumber, pageSite));
        }
        public ActionResult DanhMuc(int ? page,string id)
        {
            int pageSite = 8;
            int pageNumber = (page ?? 1);
            var loai = data.LoaiSanPham.SingleOrDefault(s => s.MaLoai == id);
            if (loai == null)
            {
                ViewBag.title = "Không thấy";
                return View();
            }
            else
            {
                ViewBag.title = loai.TenLoai;
                List<SanPham> dsspcungloai = spmodel.GetSPByLoai(id);
                return View(dsspcungloai.ToPagedList(pageNumber, pageSite));
            }
        }
        public ActionResult ChiTietSanPham(string id)
        {
            SanPham sanpham = data.SanPham.SingleOrDefault(n => n.MaSanPham == id);
            if (sanpham == null)
            {
                //Trả về trang báo lỗi
                Response.StatusCode = 404;
                return null;

            }
            else
            {
                ViewBag.TenLoaiSP = data.LoaiSanPham.Single(n => n.MaLoai == sanpham.MaLoai).TenLoai;
                return View(sanpham);
            }
        }
    }
}