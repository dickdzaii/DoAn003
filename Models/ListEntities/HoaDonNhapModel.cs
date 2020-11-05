using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class HoaDonNhapModel
    {
        Connecting knoi = new Connecting();
        public List<HoaDonNhap> DanhSachHoaDonNhap()
        {
            DataTable dt = knoi.getdata("Select* from HoaDonNhap");
            List<HoaDonNhap> li = new List<HoaDonNhap>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDonNhap hdn = new HoaDonNhap();
                hdn.MaHoaDonNhap =dr[0].ToString();
                hdn.MaNhaCungCap = (dr[1].ToString());
                hdn.NgayNhap = DateTime.Parse(dr[2].ToString());
                hdn.MaNhanVien = (dr[3].ToString());
                li.Add(hdn);
            }
            return li;
        }
        public HoaDonNhap Get1HDN(string id)
        {
            DataTable dt = knoi.getdata("Select* from HoaDonNhap where MaHoaDonNhap='" + id + "'");
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.MaHoaDonNhap = (dt.Rows[0][0].ToString());
            hdn.MaNhaCungCap = (dt.Rows[0][1].ToString());
            hdn.NgayNhap = DateTime.Parse(dt.Rows[0][2].ToString());
            hdn.MaNhanVien = (dt.Rows[0][3].ToString());
            return hdn;
        }
        public void XoaMotHDN(string id)
        {
            string sql = "delete from HoaDonNhap where MaHoaDonNhap='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotHDN(HoaDonNhap x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into HoaDonNhap values('" + x.MaNhaCungCap + "','" + x.NgayNhap+ "','" + x.MaNhanVien + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotHDN(HoaDonNhap x)
        {
            string sql = "update HoaDonNhap set MaNhaCungCap='" + x.MaNhaCungCap + "', NgayNhap='" + x.NgayNhap + "',MaNhanVien='" + x.MaNhanVien + "Where MaHoaDonNhap='"+x.MaHoaDonNhap+ "'";
            knoi.ghiDuLieu(sql);
            
        }
       
    }
}