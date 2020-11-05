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
    public class CartController : Controller
    {
        WebCayCanhDB data = new WebCayCanhDB();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cart()
        {
            List<Cart> giohang = Session["YourCart"] as List<Cart>;
            return View(giohang);
        }
        //thêm
        public ActionResult ThemVaoGio(string Masp)
        {
            if (Session["YourCart"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["YourCart"] = new List<Cart>();  // Khởi tạo Session["giohang"] là 1 List<Cart>
            }

            List<Cart> giohang = Session["YourCart"] as List<Cart>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.Masp == Masp) == null) // ko co sp nay trong gio hang
            {
                SanPham sp = data.SanPham.Find(Masp);  // tim sp theo sanPhamID

                Cart newItem = new Cart()
                {
                    Masp = Masp,
                    Tensp = sp.TenSanPham,
                    SL = 1,
                    Anh = sp.Anh,
                    DonGia = (int)sp.GiaBan

                };  // Tạo ra 1 Cart mới

                giohang.Add(newItem);  // Thêm Cart vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                Cart cardItem = giohang.FirstOrDefault(m => m.Masp == Masp);
                cardItem.SL++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("Cart", "Cart");
        }
        public RedirectToRouteResult SuaSoLuong(string Masp, int soluongmoi)
        {
            // tìm carditem muon sua
            List<Cart> giohang = Session["YourCart"] as List<Cart>;
            Cart itemSua = giohang.FirstOrDefault(m => m.Masp == Masp);
            if (itemSua != null)
            {
                itemSua.SL = soluongmoi;
            }
            return RedirectToAction("Cart", "Cart");

        }
        public RedirectToRouteResult XoaKhoiGio(string Masp)
        {
            List<Cart> giohang = Session["YourCart"] as List<Cart>;
            Cart itemXoa = giohang.FirstOrDefault(m => m.Masp == Masp);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Cart","Cart");
        }
        public ActionResult giam1sanpham(string id)
        {
            //khai bao 1 gio hang
           
            //gán giá trị session đang lưu cho biến gh
            var gh = (List<Cart>)Session["YourCart"];
            //khai báo 1 sp test sao cho ma sp trung voi masp trong gio hang
            var test = gh.Find(s => s.Masp.ToString().Contains(id.Trim()));
            //khai bao so luong dang co cua san pham test
            int soluongsp = int.Parse(test.SL.ToString());
            //Neu so luong>1
            if (soluongsp > 1)
            {
                test.SL = soluongsp - 1;
            }
            else
            {
                gh.Remove(test);
            }
            Session["YourCart"] = gh;
            return Redirect("~/Cart/Cart");
        }
        public ActionResult tang1sanpham(string id)
        {
            //khai bao 1 gio hang

            //gán giá trị session đang lưu cho biến gh
            var gh = (List<Cart>)Session["YourCart"];
            //khai báo 1 sp test sao cho ma sp trung voi masp trong gio hang
            var test = gh.Find(s => s.Masp.ToString().Contains(id.Trim()));
            //khai bao so luong dang co cua san pham test
            int soluongsp = int.Parse(test.SL.ToString());
            //Neu so luong>1
           if(test!=null)
                test.SL = soluongsp + 1;
            Session["YourCart"] = gh;
            return Redirect("~/Cart/Cart");
        }
        public ActionResult DatHang()
        {
            return View();
        }
        public ActionResult DatHangThanhCong(string hoten, string gioitinh, string diachi, string sdt, string email)
        {
            DonHang dh = new DonHang();
            if (Session["YourCart"] != null)
            {
                var giohang = Session["YourCart"] as List<Cart>;

                var khach = Session["khachhang"] as KhachHang;
                if (khach != null)
                {
                    dh.MaKhachHang = khach.MaKhachHang;
                    hoten = khach.HoTen;
                    gioitinh = khach.GioiTinh;
                    diachi = khach.DiaChi;
                    sdt = khach.SoDienThoai;
                    email = khach.Email;
                }
                else
                {
                    KhachHang kh = new KhachHang();
                    kh.HoTen = hoten;
                    kh.GioiTinh = gioitinh;
                    kh.DiaChi = diachi;
                    kh.SoDienThoai = sdt;
                    kh.Email = email;
                    kh.MatKhau = null;
                    data.KhachHang.Add(kh);
                    data.SaveChanges();
                    dh.MaKhachHang = kh.MaKhachHang;
                }
                
                dh.NgayDatHang = DateTime.Now;
                dh.TrangThai = "chưa xác nhận";
                dh.NgayXacNhan = null;
                dh.NgayGiaoHang = null;
                dh.NgayThanhToan = null;
                data.DonHang.Add(dh);
                data.SaveChanges();
                foreach (var item in giohang)
                {
                    ChiTietDonHang ct = new ChiTietDonHang();
                    ct.MaDonHang = dh.MaDonHang;
                    ct.MaSanPham = item.Masp;
                    ct.Anh = item.Anh;
                    ct.TenSanPham = item.Tensp;
                    ct.SoLuong = item.SL;
                    ct.DonGia = item.DonGia;
                    ct.ThanhTien = item.ThanhTien;
                    data.ChiTietDonHang.Add(ct);
                    data.SaveChanges();
                    
                }
               

            }
            Session["YourCart"] = null;
            return RedirectToAction("Home","TrangChu");
        }
    }
}