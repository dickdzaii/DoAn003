using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class NhanVienModel
    {
        Connecting knoi = new Connecting();
        public List<NhanVien> DanhSachNhanVien()
        {
            DataTable dt = knoi.getdata("Select* from NhanVien");
            List<NhanVien> li = new List<NhanVien>();
            foreach (DataRow dr in dt.Rows)
            {
                NhanVien staff = new NhanVien();
                staff.MaNhanVien =dr[0].ToString();
                staff.HoTen = dr[1].ToString();
                staff.NgayVaoLam = DateTime.Parse(dr[2].ToString());
                staff.NgayThoiViec = DateTime.Parse(dr[3].ToString());
                staff.TenDangNhap = dr[4].ToString();
                staff.MatKhau = dr[5].ToString();
                staff.Anh = dr[6].ToString();
                li.Add(staff);
            }
            return li;
        }
        public NhanVien Get1NV(string id)
        {
            DataTable dt = knoi.getdata("Select* from NhanVien where MaNhanVien='" + id + "'");

            NhanVien staff = new NhanVien();
            staff.MaNhanVien = (dt.Rows[0][0].ToString());
            staff.HoTen = dt.Rows[0][1].ToString();
            staff.NgayVaoLam = DateTime.Parse(dt.Rows[0][2].ToString());
            staff.NgayThoiViec = DateTime.Parse(dt.Rows[0][3].ToString());
            staff.TenDangNhap = dt.Rows[0][4].ToString();
            staff.MatKhau = dt.Rows[0][5].ToString();
            staff.Anh = dt.Rows[0][6].ToString();
            return staff;
        }
        public void XoaMotNV(string id)
        {
            string sql = "delete from NhanVien where MaNhanVien='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotNV(NhanVien x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into NhanVien values('" + x.MaNhanVien + "',N'" + x.HoTen + "','" + x.NgayVaoLam + "','" + x.NgayThoiViec + "','" + x.TenDangNhap + "','" + x.MatKhau + "','" + x.Anh + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotNV(NhanVien x)
        {
            string sql = "update NhanVien set HoTen=N'" + x.HoTen + "',NgayVaoLam='" + x.NgayVaoLam + "',NgayThoiViec='" + x.NgayThoiViec + "',TenDangNhap='" + x.TenDangNhap + "',MatKhau='" + x.MatKhau + "',Anh='" + x.Anh + "where MaNhanVien='" + x.MaNhanVien + "'";
            knoi.ghiDuLieu(sql);
        }
    }
}
