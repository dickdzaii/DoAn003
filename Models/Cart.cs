using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn003.Models
{
    public class Cart
    {
        public string Masp { get; set; }
        public string Tensp { get; set; }
        public string Anh { get; set; }
        public int SL { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien
        {
            get
            {
                return SL * DonGia;
            }
        }
    }
}