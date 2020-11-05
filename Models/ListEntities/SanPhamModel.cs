using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class SanPhamModel
    {
        Connecting knoi = new Connecting();
        public List<SanPham> DanhSachSanPham()
        {
            DataTable dt = knoi.getdata("Select* from SanPham");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = (dr[0].ToString());
                sp.TenSanPham = dr[1].ToString();
                sp.MaLoai = (dr[2].ToString());
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.Anh = dr[4].ToString();
                sp.Mota = dr[5].ToString();
                sp.GiaBan = int.Parse(dr[6].ToString());
                li.Add(sp);
            }
            return li;
        }
        public SanPham Get1SP(string id)
        {
            DataTable dt = knoi.getdata("Select* from SanPham where MaSanPham='" + id + "'");

            SanPham sp = new SanPham();
            sp.MaSanPham = (dt.Rows[0][0].ToString());
            sp.TenSanPham = dt.Rows[0][1].ToString();
            sp.MaLoai = (dt.Rows[0][2].ToString());
            sp.SoLuong = int.Parse(dt.Rows[0][3].ToString());
            sp.Anh = dt.Rows[0][4].ToString();
            sp.Mota = dt.Rows[0][5].ToString();
            sp.GiaBan = int.Parse(dt.Rows[0][6].ToString());
            return sp;
        }
        public List<SanPham> GetSPByLoai(string id)
        {
            DataTable dt = knoi.getdata("Select* from SanPham where MaLoai='" + id + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = (dr[0].ToString());
                sp.TenSanPham = dr[1].ToString();
                sp.MaLoai = (dr[2].ToString());
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.Anh = dr[4].ToString();
                sp.Mota = dr[5].ToString();
                sp.GiaBan = int.Parse(dr[6].ToString());
                li.Add(sp);
            }
            return li;
        }
        public void XoaMotSP(string id)
        {
            string sql = "delete from SanPham where MaSanPham='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotSP(SanPham x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into SanPham values('"+x.MaSanPham+"',N'" + x.TenSanPham + "','" + x.MaLoai + "','" + x.SoLuong + "','" + x.Anh + "',N'" + x.Mota + "','" + x.GiaBan + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotSP(SanPham x)
        {
            string sql = "update SanPham set TenSanPham=N'" + x.TenSanPham + "',MaLoai='" + x.MaLoai + "',SoLuong='" + x.SoLuong + "',Anh='" + x.Anh + "' ,Mota=N'" + x.Mota + "' ,GiaBan='" + x.GiaBan + "'where MaSanPham='" + x.MaSanPham + "'";
            knoi.ghiDuLieu(sql);
        }
    }
}