using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
using Newtonsoft.Json;
using System.Security.Authentication;
namespace DoAn003.Controllers.Clt
{
    public class DangNhapVaDangKyController : Controller
    {
        KhachHangModel a = new KhachHangModel();
        WebCayCanhDB data = new WebCayCanhDB();
        // GET: DangNhapVaDangKy
        public ActionResult Index()
        {
            KhachHang kh = new KhachHang();
            var json = JsonConvert.SerializeObject(kh);
            HttpCookie user = new HttpCookie("email",json);
            return RedirectToAction("login");
        }
        public HttpCookie DangNhap(string email, string mk)
        {
            
            var newUser = data.KhachHang.SingleOrDefault(s => s.Email == email && s.MatKhau == mk);
            if (newUser != null)
            {
                var json = JsonConvert.SerializeObject(newUser);
                //tạo cookie mới (tên cookie:user, giá trị:tdn+mk)
                var userCookie = new HttpCookie("user", json);
                //tạo ngày hết hạn cookie(optional)
                userCookie.Expires.AddYears(60);
                //tạo một respone để mỗi khi truy cập cookie tự xuất hiện
                Response.Cookies.Add(userCookie);
                return userCookie;
            }
            else return null;
        }
        public ActionResult login(string email,string mk)
        {
            
                var newUser = data.KhachHang.SingleOrDefault(s=>s.Email==email&& s.MatKhau==mk);
            if (newUser != null)
            {
                Session["khachhang"]=newUser;
                Session["email"] = newUser.Email;
                //Session["mk"] = newUser.MatKhau;
                return Redirect("~/TrangChu/Home");
            }
            else
            {
                ViewBag.kqlogin = "tên tài khoản hoặc mật khẩu không chính xác";
                return View();
            }
        }
        public ActionResult logout()
        {
            Session["khachhang"] = null;
            Session["email"] = null;
            return  Redirect("~/TrangChu/Home");
        } 
        public ActionResult signup( string hoten, string diachi, string sdt, string email, string gt, DateTime? ngaysinh, string mk)
        {
            var x= data.KhachHang.SingleOrDefault(s=>s.Email==email);
            if (x == null)
            {
                KhachHang cst = new KhachHang();
                cst.HoTen = hoten;
                cst.DiaChi = diachi;
                cst.SoDienThoai = sdt;
                cst.Email = email;
                cst.GioiTinh = gt;
                cst.NgaySinh = ngaysinh;
                cst.MatKhau = mk;
                data.KhachHang.Add(cst);
                data.SaveChanges();
                Session["khachhang"] = cst;
                Session["email"] = cst.Email;
                
                return RedirectToAction("Home", "TrangChu");
            }
            else return View();
            
        }
    }
}