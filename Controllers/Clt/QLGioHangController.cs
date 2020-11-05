using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
using PagedList;

namespace DoAn003.Controllers.Clt
{
    public class QLGioHangController : Controller
    {
        // GET: QLGioHang
        public ActionResult Index()
        {
            return View();
        }
        WebCayCanhDB db = new WebCayCanhDB();
        #region Giỏ hàng
        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {

            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //nếu giỏ hàng chưa tồn tại thì tiến hành khởi tạo list giỏ hàng(session GioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult Cart()
        {
            List<Cart> giohang = Session["YourCart"] as List<Cart>;
            return View(giohang);
        }
        //thêm giỏ hàng
        public ActionResult ThemGioHang(string iMaSP)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSanPham == iMaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sản phẩm này đã tồn tại trong session[GioHang] hay chưa...
            GioHang gh = lstGioHang.Find(n => n.iMaSP == iMaSP);
            if (gh == null)
            {
                gh = new GioHang(iMaSP);
                //Add sản phẩm vào list
                lstGioHang.Add(gh);
                return Redirect("~/QLGioHang/GioHang");
            }
            else
            {

                gh.iSoLuong = gh.iSoLuong + 1;
                return Redirect("~/QLGioHang/GioHang");
            }
        }
        //sửa giỏ hàng
        public ActionResult CapNhatGioHang(string iMaSP, FormCollection f)
        {
            //Kiểm tra mã sản phẩm 
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSanPham == iMaSP);
            //nếu get sai mã sản phẩm thì trả về trang lỗi
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sản phẩm có tồn tại trong session[GioHang]
            GioHang gh = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP);
            //Nếu tồn tại thì cho phép sửa số lượng
            if (gh != null)
            {
                gh.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return Redirect("~/QLGioHang/GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(string iMaSP)
        {
            //Kiểm tra mã sản phẩm 
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSanPham == iMaSP);
            //nếu get sai mã sản phẩm thì trả về trang lỗi
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sản phẩm có tồn tại trong session[GioHang]
            GioHang gh = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP);
            //Nếu tồn tại thì cho phép xóa 
            if (gh != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSP == iMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Home", "TrangChu");
            }
            return RedirectToAction("GioHang");
        }
        //xây dựng trang giỏ hàng	
        public ActionResult GioHang()
        {

            List<GioHang> lstgiohang = LayGioHang();
            return View(lstgiohang);
        }
        //tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //tính tổng tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dThanhTien);

            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Home", "TrangChu");
            }
            List<GioHang> lstgiohang = LayGioHang();
            return View(lstgiohang);
        }
        #endregion

        #region Đặt hàng
        //xây dựng chức năng đặt hàng

       
        #endregion
        [HttpPost]
        public ActionResult DatHangThanhCong()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangNhapVaDangKy");
            }
            //Thêm đơn đặt hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Home", "TrangChu");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.MaKhachHang = kh.MaKhachHang;
            ddh.NgayDatHang = DateTime.Now;
            db.DonHang.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaSanPham = item.iMaSP;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (int)item.dDonGia;
                db.ChiTietDonHang.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Home", "TrangChu");
        }
    }
}
