using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class ChucVuModel
    {
        Connecting knoi = new Connecting();
        public List<ChucVu> DanhSachChucVu()
        {
            DataTable dt = knoi.getdata("Select* from ChucVu");
            List<ChucVu> li = new List<ChucVu>();
            foreach (DataRow dr in dt.Rows)
            {
                ChucVu pst = new ChucVu();
                pst.MaChucVu =dr[0].ToString();
                pst.TenChucVu = dr[1].ToString();
                li.Add(pst);
            }
            return li;
        }
        public ChucVu Get1CV(string id)
        {
            DataTable dt = knoi.getdata("Select* from ChucVu where MaChucVu='" + id + "'");
            ChucVu pst = new ChucVu();
            pst.MaChucVu = (dt.Rows[0][0].ToString());
            pst.TenChucVu = dt.Rows[0][1].ToString();
            return pst;
        }
        public void XoaMotCV(string id)
        {
            string sql = "delete from ChucVu where MaChucVu='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotCV(ChucVu x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into ChucVu values(N'" + x.TenChucVu + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotCV(ChucVu x)
        {
            string sql = "update ChucVu set TenChucVu=N'" + x.TenChucVu + "'where MaChucVu='"+x.MaChucVu+"'";
            knoi.ghiDuLieu(sql);
        }
    }
}