using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class LoaiSanPhamModel
    {
        Connecting knoi = new Connecting();
        public List<LoaiSanPham> DanhSachLoai()
        {
            DataTable dt = knoi.getdata("Select* from LoaiSanPham");
            List<LoaiSanPham> li = new List<LoaiSanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham loai = new LoaiSanPham();
                loai.MaLoai =dr[0].ToString();
                loai.TenLoai = dr[1].ToString();
                loai.MoTa = dr[2].ToString();
                li.Add(loai);
            }
            return li;
        }
        public LoaiSanPham Get1Loai(string id)
        {
            DataTable dt = knoi.getdata("Select* from LoaiSanPham where MaLoai='" + id + "'");

            LoaiSanPham loai = new LoaiSanPham();
            loai.MaLoai = (dt.Rows[0][0].ToString());
            loai.TenLoai = dt.Rows[0][1].ToString();
            loai.MoTa = dt.Rows[0][2].ToString();
            return loai;
        }
        public LoaiSanPham Layloaitheosp(string id)
        {
            DataTable dt = knoi.getdata("Select* from LoaiSanPham l inner join SanPham sp on l.MaLoai=sp.MaLoai where MaSanPham='" + id + "'");

            LoaiSanPham loai = new LoaiSanPham();
            loai.MaLoai = (dt.Rows[0][0].ToString());
            loai.TenLoai = dt.Rows[0][1].ToString();
            loai.MoTa = dt.Rows[0][2].ToString();
            return loai;
        }
        public void XoaMotLoai(string id)
        {
            string sql = "delete from LoaiSanPham where MaLoai='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotLoai(LoaiSanPham x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into LoaiSanPham values('"+x.MaLoai+"',N'" + x.TenLoai + "',N'" + x.MoTa + "')";
            knoi.ghiDuLieu(sql);
        }
        
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotLoai(LoaiSanPham x)
        {
            string sql = "update LoaiSanPham set TenLoai=N'" + x.TenLoai + "',MoTa=N'" + x.MoTa + "' Where MaLoai='"+x.MaLoai+"'";
            knoi.ghiDuLieu(sql);
        }
    }
}