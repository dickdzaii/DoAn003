using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class HoaDonBanModel
    {
        Connecting knoi = new Connecting();
        public List<HoaDonBan> DanhSachHoaDonBan()
        {
            DataTable dt = knoi.getdata("Select* from HoaDonBan");
            List<HoaDonBan> li = new List<HoaDonBan>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDonBan hdb = new HoaDonBan();
                hdb.MaHoaDonBan =dr[0].ToString();
                hdb.MaDonHang = (dr[1].ToString());
                hdb.MaNhanVien =(dr[2].ToString());
                hdb.TongThanhTien = int.Parse(dr[3].ToString());
                hdb.NgayBan = DateTime.Parse(dr[4].ToString());
                li.Add(hdb);
            }
            return li;
        }
        public HoaDonBan Get1HDB(string id)
        {
            DataTable dt = knoi.getdata("Select* from HoaDonBan where MaHoaDonBan='" + id + "'");
            HoaDonBan hdb = new HoaDonBan();
            hdb.MaHoaDonBan = (dt.Rows[0][0].ToString());
            hdb.MaDonHang = (dt.Rows[0][1].ToString());
            hdb.MaNhanVien = (dt.Rows[0][2].ToString());
            hdb.TongThanhTien = int.Parse(dt.Rows[0][3].ToString());
            hdb.NgayBan = DateTime.Parse(dt.Rows[0][4].ToString());
            return hdb;
        }
        public List<HoaDonBan> layhdbtheothang( int month,int year)
        {
            DataTable dt = knoi.getdata("select*from HoaDonBan where Year(NgayBan)='"+year+"' and MONTH(NgayBan)='"+month+"'");
            List<HoaDonBan> li = new List<HoaDonBan>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDonBan hdb = new HoaDonBan();
                hdb.MaHoaDonBan =dr[0].ToString();
                hdb.MaDonHang = (dr[1].ToString());
                hdb.MaNhanVien = (dr[2].ToString());
                hdb.TongThanhTien = int.Parse(dr[3].ToString());
                hdb.NgayBan = DateTime.Parse(dr[4].ToString());
                li.Add(hdb);
            }
            return li;
        }
        public void XoaMotHDB(string id)
        {
            string sql = "delete from HoaDonBan where MaHoaDonBan='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotHDB(HoaDonBan x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into HoaDonBan values('" + x.MaNhanVien + "','" + x.TongThanhTien + "','" + x.NgayBan + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotHDB(HoaDonBan x)
        {
            string sql = "update HoaDonBan set MaDonHang='" + x.MaDonHang + "', MaNhanVien='" + x.MaNhanVien + "', NgayBan='" + x.NgayBan + "'where MaHoaDonBan='"+x.MaHoaDonBan+"'";
            knoi.ghiDuLieu(sql);
        }
    }
}