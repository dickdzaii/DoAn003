using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
namespace DoAn003.Controllers.Ser
{
    public class ThongKeBaoCaoController : Controller
    {
        // GET: ThongKeBaoCao
        WebCayCanhDB data = new WebCayCanhDB();
        HoaDonBanModel qlhdb = new HoaDonBanModel();
        ChiTietDonHangModel qlctdh= new ChiTietDonHangModel();
        DonHangModel qldh = new DonHangModel();
        SanPhamModel qlsp = new SanPhamModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DonHangTheoThang(int month,int year)
        {
            ViewBag.abc = "Đơn hàng đã thanh toán trong tháng " + month + " năm " + year;
            List<DonHang> dshdb = qldh.laydonhangtheothang(month, year);
            return View(dshdb);
        }
        public ActionResult BanChayTheoThang(int a)
        {

            /*ý tưởng là sắp xếp sản phẩm bán được trong một tháng 
             * theo số lượng từ lớn nhất đến nhỏ nhất
             */
            return View();
        }
        [HttpGet]
        public ActionResult HoaDonBanTheoThang(int month, int year)
        {
            ViewBag.TieuDe = "Hóa đơn đã xuất trong tháng " + month + " năm " + year;
            List<HoaDonBan> dshdb = qlhdb.layhdbtheothang(month,year);
            return View(dshdb);
        }
        public ActionResult chitietdonhang(string id,int month, int year)
        {
            List<DonHang> dsdh = qldh.laydonhangtheothang(month, year);
            List<ChiTietDonHang> dsctdh = qlctdh.DanhSachChiTietDonHang();
            ChiTietDonHang ct= dsctdh.Find(s=>s.MaDonHang==id);
            return Json(ct,JsonRequestBehavior.AllowGet);
        }
    }
}