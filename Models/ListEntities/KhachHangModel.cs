using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class KhachHangModel
    {
        Connecting knoi = new Connecting();
        public List<KhachHang> DanhSachKhachHang()
        {
            DataTable dt = knoi.getdata("Select* from KhachHang");
            List<KhachHang> li = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang cst = new KhachHang();
                cst.MaKhachHang = (dr[0].ToString());
                cst.HoTen = dr[1].ToString();
                cst.DiaChi = dr[2].ToString();
                cst.SoDienThoai = dr[3].ToString();
                cst.Email = dr[4].ToString();

                li.Add(cst);
            }
            return li;
        }
        
        public KhachHang Get1KH(string id)
        {
            DataTable dt = knoi.getdata("Select* from KhachHang where MaKhachHang='" + id + "'");

            KhachHang cst = new KhachHang();
            cst.MaKhachHang = (dt.Rows[0][0].ToString());
            cst.HoTen = dt.Rows[0][1].ToString();
            cst.DiaChi = dt.Rows[0][2].ToString();
            cst.SoDienThoai = dt.Rows[0][3].ToString();
            cst.Email = dt.Rows[0][4].ToString();
            cst.GioiTinh = dt.Rows[0][5].ToString();
            cst.NgaySinh = DateTime.Parse(dt.Rows[0][6].ToString());
            cst.MatKhau=dt.Rows[0][7].ToString();
            return cst;
        }
        public void XoaMotKH(string id)
        {
            string sql = "delete from KhachHang where MaKhachHang='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotKH(KhachHang x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into KhachHang values(N'" + x.HoTen + "',N'" + x.DiaChi + "','" + x.SoDienThoai + "','" + x.Email + "',N'" + x.GioiTinh + "','" +x.NgaySinh + "','"+x.MatKhau+"')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotKH(KhachHang x)
        {
            string sql = "update KhachHang set HoTen=N'" + x.HoTen + "',DiaChi=N'" + x.DiaChi+ "',SoDienThoai='" +x.SoDienThoai+ "',Email='" + x.Email + "',GioiTinh=N'" + x.GioiTinh + "',NgaySinh='" + x.NgaySinh+ "',MatKhau='"+x.MatKhau+"' where MaKhachHang='" + x.MaKhachHang + "'";
            knoi.ghiDuLieu(sql);
        }
    }
}