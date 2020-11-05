using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class DonHangModel
    {
        Connecting knoi = new Connecting();
        public List<DonHang> DanhSachDonHang()
        {
            DataTable dt = knoi.getdata("Select* from DonHang");
            List<DonHang> li = new List<DonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                DonHang odr = new DonHang();
                odr.MaDonHang = (dr[0].ToString());
                odr.MaKhachHang = (dr[1].ToString());
                odr.NgayDatHang = DateTime.Parse(dr[2].ToString());
                odr.TrangThai = dr[3].ToString();
                li.Add(odr);
            }
            return li;
        }
        public List<DonHang> laydonhangtheothang(int month, int year)
        {
            DataTable dt = knoi.getdata("Select* from DonHang where Month(NgayDatHang)='"+month+"' and YEAR(NgayDatHang)='"+year+"'");
            List<DonHang> li = new List<DonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                DonHang odr = new DonHang();
                odr.MaDonHang = (dr[0].ToString());
                odr.MaKhachHang = (dr[1].ToString());
                odr.NgayDatHang = DateTime.Parse(dr[2].ToString());
                odr.TrangThai = dr[3].ToString();
                li.Add(odr);
            }
            return li;
        }
        public DonHang Get1DonHang(string id)
        {
            DataTable dt = knoi.getdata("Select* from DonHang where MaDonHang='" + id + "'");
            DonHang odr = new DonHang();
            odr.MaDonHang = (dt.Rows[0][0].ToString());
            odr.MaKhachHang = (dt.Rows[0][1].ToString());
            odr.NgayDatHang = DateTime.Parse(dt.Rows[0][2].ToString());
            odr.TrangThai = dt.Rows[0][3].ToString();
            return odr;
        }
        
        public void XoaMotDonHang(string id)
        {
            DateTime a = DateTime.Now;
            a.ToShortTimeString();
            string sql = "delete from DonHang where MaDonHang='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotDonHang(DonHang x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into DonHang values('" + x.MaKhachHang + "','" + x.NgayDatHang + "',N'" + x.TrangThai + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(System.DateTime t)
        {
            string kq;
                kq = t.ToShortDateString();
            return kq;
        }
        public void CapNhatMotDonHang(DonHang x)
        {
            string sql = "update DonHang set MaKhachHang=N'" + x.MaKhachHang + "',NgayDatHang='" + x.NgayDatHang + "',TrangThai=N'" + x.TrangThai + "'where MaDonHang='"+x.MaDonHang+"'";
            knoi.ghiDuLieu(sql);
        }
    }
}