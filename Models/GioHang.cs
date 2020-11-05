using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn003.Models;

namespace DoAn003.Models
{
    public class GioHang
    {
        WebCayCanhDB db = new WebCayCanhDB();

        public string iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sHinhAnh { get; set; }
        public int dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public int dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //hàm tạo cho giỏ hàng
        public GioHang(string MaSP)
        {
            iMaSP = MaSP;
            SanPham sp = db.SanPham.Single(n => n.MaSanPham == iMaSP);
            sTenSP = sp.TenSanPham;
            sHinhAnh = sp.Anh;
            dDonGia = int.Parse(sp.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}
    