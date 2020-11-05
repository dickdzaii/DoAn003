using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class NhaCungCapModel
    {
        Connecting knoi = new Connecting();
        public List<NhaCungCap> DanhSachNCC()
        {
            DataTable dt = knoi.getdata("Select* from NhaCungCap");
            List<NhaCungCap> li = new List<NhaCungCap>();
            foreach (DataRow dr in dt.Rows)
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNhaCungCap =dr[0].ToString();
                ncc.TenNhaCungCap = dr[1].ToString();
                ncc.DiaChi = dr[2].ToString();
                ncc.SoDienThoai = dr[3].ToString();
                li.Add(ncc);
            }
            return li;
        }
        public NhaCungCap Get1NCC(string id)
        {
            DataTable dt = knoi.getdata("Select* from NhaCungCap where MaNhaCungCap='" + id + "'");
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNhaCungCap = (dt.Rows[0][0].ToString());
            ncc.TenNhaCungCap = dt.Rows[0][1].ToString();
            ncc.DiaChi = dt.Rows[0][2].ToString();
            ncc.SoDienThoai = dt.Rows[0][3].ToString();
            return ncc;
        }
        public void XoaMotNCC(string id)
        {
            string sql = "delete from NhaCungCap where MaNhaCungCap='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotNCC(NhaCungCap x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into NhaCungCap values(N'" + x.TenNhaCungCap + "',N'" + x.DiaChi + "','" + x.SoDienThoai + "')";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotNCC(NhaCungCap x)
        {
            string sql = "update NhaCungCap SET TenNhaCungCap=N'" + x.TenNhaCungCap + "',DiaChi=N'"+x.DiaChi+ "',SoDienThoai='" + x.SoDienThoai + "'where MaNhaCungCap="+x.MaNhaCungCap+"";
            knoi.ghiDuLieu(sql);
        }
    }
}
