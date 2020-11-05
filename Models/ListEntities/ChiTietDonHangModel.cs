using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DoAn003.Models.ListEntities
{
    public class ChiTietDonHangModel
    {
        Connecting knoi = new Connecting();
        public List<ChiTietDonHang> DanhSachChiTietDonHang()
        {
            DataTable dt = knoi.getdata("Select* from ChiTietDonHang");
            List<ChiTietDonHang> li = new List<ChiTietDonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.MaChiTiet =dr[0].ToString();
                ct.MaDonHang = (dr[1].ToString());
                ct.MaSanPham = (dr[2].ToString());
                ct.SoLuong = int.Parse(dr[3].ToString());
                ct.DonGia = int.Parse(dr[4].ToString());
                ct.ThanhTien = int.Parse(dr[5].ToString());
                li.Add(ct);
            }
            return li;
        }
        public ChiTietDonHang Get1CT(string id)
        {
            DataTable dt = knoi.getdata("Select* from ChiTietDonHang where MaChiTiet='" + id + "'");
            ChiTietDonHang ct = new ChiTietDonHang();
            ct.MaChiTiet = (dt.Rows[0][0].ToString());
            ct.MaDonHang = (dt.Rows[0][1].ToString());
            ct.MaSanPham = (dt.Rows[0][2].ToString());
            ct.TenSanPham =dt.Rows[0][3].ToString();
            ct.Anh = dt.Rows[0][4].ToString();
            ct.SoLuong = int.Parse(dt.Rows[0][5].ToString());
            ct.DonGia = int.Parse(dt.Rows[0][6].ToString());
            ct.ThanhTien = int.Parse(dt.Rows[0][7].ToString());
            return ct;
        }
        public List<ChiTietDonHang> LayCTTheoDonHang(string id)
        {
            DataTable dt = knoi.getdata("Select* from ChiTietDonHang where MaDonHang='" + id + "'");
            List<ChiTietDonHang> li = new List<ChiTietDonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.MaChiTiet =dr[0].ToString();
                ct.MaDonHang = (dr[1].ToString());
                ct.MaSanPham = (dr[2].ToString());
                ct.TenSanPham = dr[3].ToString();
                ct.Anh = dr[4].ToString();
                ct.SoLuong = int.Parse(dr[5].ToString());
                ct.DonGia = int.Parse(dr[6].ToString());
                ct.ThanhTien = int.Parse(dr[7].ToString());
                li.Add(ct);
            }
            return li;
        }
        public void XoaMotCT(string id)
        {
            string sql = "delete from ChiTietDonHang where MaChiTiet='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
        public void ThemMotCT(ChiTietDonHang x)
        {   //this: goi đến 1 lớp trong model này
            string sql = "insert into ChiTietDonHang values('" + x.MaDonHang + "','"+x.MaSanPham+"',"+x.SoLuong+","+x.DonGia+","+x.ThanhTien+")";
            knoi.ghiDuLieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
        public void CapNhatMotCT(ChiTietDonHang x)
        {
            string sql = "update ChiTietDonHang set MaDonHang='" + x.MaDonHang + "', MaSanPham='" + x.MaSanPham+ "', SoLuong='" + x.SoLuong + "', DonGia='" + x.DonGia + "', ThanhTien='" + x.ThanhTien + "'where MaChiTiet='" + x.MaChiTiet + "'";
            knoi.ghiDuLieu(sql);
        }
        public void capnhatsoluong(int soluong, string id,string trangthai)
        {
            string sql = "update SanPham set SoLuong=SoLuong-'" + soluong + "' Where MaSanPham='" + id + "'";
            knoi.ghiDuLieu(sql);
        }
    }
}