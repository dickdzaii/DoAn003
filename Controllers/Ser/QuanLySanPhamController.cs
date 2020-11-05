using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models.ListEntities;
using DoAn003.Models;
using PagedList;
using PagedList.Mvc;
namespace DoAn003.Controllers.Ser
{
    public class QuanLySanPhamController : Controller
    {
        WebCayCanhDB data = new WebCayCanhDB();
        // GET: QuanLySanPham
        SanPhamModel qlsp = new SanPhamModel();
     
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult quanlysanpham(int ? page)
        {
            int pageSite = 10;

            int pageNumber = (page ?? 1);


            return View(data.SanPham.OrderBy(n => n.MaSanPham).ToPagedList(pageNumber, pageSite));
        }
        public ActionResult laymotsp(string id)
        {
            var spcanlay = qlsp.Get1SP(id);
            return Json(spcanlay, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoamotsp(string id)
        {
            qlsp.XoaMotSP(id);
            return Redirect("~/QuanLySanPham/quanlysanpham");
        }
        public ActionResult themvasuasp(string tensp,string maloai, int soluong,int? giaban,HttpPostedFileBase anh, string aoe)
        {
            LoaiSanPham loaia=data.LoaiSanPham.FirstOrDefault(n=>n.MaLoai==maloai);
            SanPham sanpham = new SanPham();
            sanpham.MaSanPham="SP"+(data.SanPham.Count()+1).ToString();
            sanpham.TenSanPham = tensp;
            sanpham.MaLoai  = maloai;
            sanpham.SoLuong = soluong;
            sanpham.GiaBan=giaban;
            if (anh.ContentLength >= 0)
            {
                string path = Server.MapPath("~/Assets/Clt/images/Products/New/") + anh.FileName; //đường dẫn đến ảnh, anh.FileName là tên ảnh
                
                anh.SaveAs(path);
                
                sanpham.Anh = anh.FileName;
            }
            else sanpham.Anh = null;
            if (aoe == "1")
            {
                qlsp.ThemMotSP(sanpham);
              
            }
            else
            {
                qlsp.CapNhatMotSP(sanpham);               
            }
            return Redirect("~/QuanLySanPham/quanlysanpham");
        }

    }
}