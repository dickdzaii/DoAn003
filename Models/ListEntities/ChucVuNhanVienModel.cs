using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class ChucVuNhanVienNhanVienModel
    {       
            Connecting knoi = new Connecting();
            public List<ChucVuNhanVien> DanhSachChucVuNhanVien()
            {
                DataTable dt = knoi.getdata("Select* from ChucVuNhanVien");
                List<ChucVuNhanVien> li = new List<ChucVuNhanVien>();
                foreach (DataRow dr in dt.Rows)
                {
                    ChucVuNhanVien pst = new ChucVuNhanVien();
                    pst.MaCVNV = (dr[0].ToString());
                    pst.MaNhanVien = (dr[1].ToString());
                    pst.MaChucVu = (dr[2].ToString());
                    li.Add(pst);
                }
                return li;
            }
            public ChucVuNhanVien Get1CV(string id)
            {
                DataTable dt = knoi.getdata("Select* from ChucVuNhanVien where MaCVNV='" + id + "'");
                ChucVuNhanVien pst = new ChucVuNhanVien();
                pst.MaCVNV = (dt.Rows[0][0].ToString());
                pst.MaNhanVien = (dt.Rows[0][1].ToString());
                pst.MaChucVu = (dt.Rows[0][2].ToString());
                return pst;
            }
            public void XoaMotCV(string id)
            {
                string sql = "delete from ChucVuNhanVien where MaCVNV='" + id + "'";
                knoi.ghiDuLieu(sql);
            }
            public void ThemMotCV(ChucVuNhanVien x)
            {   //this: goi đến 1 lớp trong model này
                string sql = "insert into ChucVuNhanVien values('" + x.MaNhanVien + "','"+x.MaChucVu+"')";
                knoi.ghiDuLieu(sql);
            }
            public string getdate(string t)
            {
                DateTime dt = DateTime.Parse(t);
                string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
                return kq;
            }
            public void CapNhatMotCV(ChucVuNhanVien x)
            {
                string sql = "update ChucVuNhanVien set MaNhanVien=N'" + x.MaNhanVien + "',MaChucVu='" + x.MaChucVu+ "'where MaCVNV='" + x.MaCVNV + "'";
                knoi.ghiDuLieu(sql);
            }
        }
    }