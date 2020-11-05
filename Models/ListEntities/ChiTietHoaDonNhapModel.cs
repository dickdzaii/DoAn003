using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn003.Models.ListEntities
{
    public class ChiTietHoaDonNhapModel
    {
        Connecting knoi = new Connecting();
        public List<ChiTietHoaDonNhap> DanhSachChiTiethoaDonNhap()
        {
            DataTable dt = knoi.getdata("Select* from ChiTietHoaDonNhap");
            List<ChiTietHoaDonNhap> li = new List<ChiTietHoaDonNhap>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietHoaDonNhap ct = new ChiTietHoaDonNhap();
                ct.MaChiTiet =dr[0].ToString();
                ct.MaHoaDonNhap = (dr[1].ToString());
                ct.MaSanPham = (dr[2].ToString());
                ct.TenSanPham = dr[3].ToString();
                ct.Anh = dr[4].ToString();
                ct.SoLuong = int.Parse(dr[5].ToString());
                ct.GiaNhap = int.Parse(dr[6].ToString());
                ct.ThanhTien = int.Parse(dr[7].ToString());
                li.Add(ct);
            }
            return li;
        }
        public ChiTietHoaDonNhap Get1CT(string id)
        {
            DataTable dt = knoi.getdata("Select* from ChiTietHoaDonNhap where MaChiTiet='" + id + "'");
            ChiTietHoaDonNhap ct = new ChiTietHoaDonNhap();
            ct.MaChiTiet = (dt.Rows[0][0].ToString());
            ct.MaHoaDonNhap = (dt.Rows[0][1].ToString());
            ct.MaSanPham = (dt.Rows[0][2].ToString());
            ct.TenSanPham= dt.Rows[0][3].ToString();
            ct.Anh = dt.Rows[0][4].ToString();
            ct.SoLuong = int.Parse(dt.Rows[0][5].ToString());
            ct.GiaNhap = int.Parse(dt.Rows[0][6].ToString());
            ct.ThanhTien = int.Parse(dt.Rows[0][7].ToString());
            return ct;
        }
        public List<ChiTietHoaDonNhap> LayChiTietTheoHD(string id)
        {
            DataTable dt = knoi.getdata("Select* from ChiTietHoaDonNhap where MaHoaDonNhap='" + id + "'");
            List<ChiTietHoaDonNhap> li = new List<ChiTietHoaDonNhap>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietHoaDonNhap ct = new ChiTietHoaDonNhap();
                ct.MaChiTiet =dr[0].ToString();
                ct.MaHoaDonNhap = (dr[1].ToString());
                ct.MaSanPham = (dr[2].ToString());
                ct.TenSanPham= dr[3].ToString();
                ct.Anh =dr[4].ToString();
                ct.SoLuong = int.Parse(dr[5].ToString());
                ct.GiaNhap = int.Parse(dr[6].ToString());
                ct.ThanhTien = int.Parse(dr[7].ToString());
                li.Add(ct);
            }
            return li;
        }
        public void XoaMotCT(string id)
        {
            string sql = "delete from ChiTietHoaDonNhap where MaChiTiet='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotCT(ChiTietHoaDonNhap x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into ChiTietHoaDonNhap values('" + x.MaHoaDonNhap + "','"+x.MaSanPham+ "','" + x.TenSanPham + "','" + x.Anh+"',"+x.SoLuong+","+x.GiaNhap+","+x.ThanhTien+")";
            knoi.ghiDuLieu(sql);
            capnhatsoluong((int)x.SoLuong,x.MaSanPham);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotCT(ChiTietHoaDonNhap x)
        {
            string sql = "update ChiTietHoaDonNhap set MaHoaDonNhap='" + x.MaHoaDonNhap + "', MaSanPham='" + x.MaSanPham+ "', TenSanPham='" + x.TenSanPham + "', Anh='" + x.Anh + "', SoLuong='" + x.SoLuong + "', GiaNhap='" + x.GiaNhap + "', ThanhTien='" + x.ThanhTien + "'where MaChiTiet='" + x.MaChiTiet + "'";
            knoi.ghiDuLieu(sql);
        }
        public void capnhatsoluong(int soluong,string id)
        {
            string sql = "update SanPham set SoLuong=SoLuong+'" + soluong + "' Where MaSanPham='"+id+"'";
            knoi.ghiDuLieu(sql);
        }
    }
}