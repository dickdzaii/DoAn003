//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn003.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHoaDonNhap
    {
        public string MaChiTiet { get; set; }
        public string MaHoaDonNhap { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Anh { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> GiaNhap { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual HoaDonNhap HoaDonNhap { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
