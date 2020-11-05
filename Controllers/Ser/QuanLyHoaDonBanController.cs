using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models.ListEntities;
using DoAn003.Models;
namespace DoAn003.Controllers.Ser
{
    public class QuanLyHoaDonBanController : Controller
    {
        // GET: QuanLyHoaDonBan
        HoaDonBanModel qlgb = new HoaDonBanModel();
        public ActionResult Index()
        {
            return View();
        }
            

            public ActionResult quanlyhdb()
            {
                List<HoaDonBan> dshdb = qlgb.DanhSachHoaDonBan();
                return View(dshdb);
            }
            public ActionResult laymothdn(string id)
            {
                var hdn = qlgb.Get1HDB(id);
                return Json(hdn, JsonRequestBehavior.AllowGet);
            }
            public ActionResult xoamothdn(string id)
            {
                qlgb.XoaMotHDB(id);
                return Redirect("~/QuanLyHoaDonBan/quanlyhdb");
            }
            public ActionResult nhaphang(string mahdn, string madh, string manv, int tongtien,DateTime ngaynhap, string aoe)
            {
                List<HoaDonBan> dslsp = qlgb.DanhSachHoaDonBan();
                HoaDonBan gia = new HoaDonBan();
                gia.MaHoaDonBan = mahdn;
                gia.MaDonHang = madh;
                gia.MaNhanVien = manv;
                gia.TongThanhTien = tongtien;
                gia.NgayBan = ngaynhap;

                if (aoe == "1")
                {
                    qlgb.ThemMotHDB(gia);
                }
                else
                {
                    qlgb.CapNhatMotHDB(gia);
                }
                return Redirect("~/QuanLyHoaDonBan/quanlyhdb");
            }
        }
    }