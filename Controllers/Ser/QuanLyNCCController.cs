using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;

namespace DoAn003.Controllers.Ser
{
    public class QuanLyNCCController : Controller
    {
        // GET: QuanLyNCC
        NhaCungCapModel qlncc = new NhaCungCapModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult quanlynhacc()
        {
            List<NhaCungCap> dsncc= qlncc.DanhSachNCC();
            return View(dsncc);
        }
        public ActionResult laymotncc(string id)
        {
            var ncccanlay = qlncc.Get1NCC(id);
            return Json(ncccanlay, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoamotncc(string id)
        {
            qlncc.XoaMotNCC(id);
            return Redirect("~/QuanLyNCC/quanlynhacc");
        }
        public ActionResult themvasuancc(string tenncc, string diachi,string sdt, string aoe)
        {
            List<NhaCungCap> dslsp = qlncc.DanhSachNCC();
            NhaCungCap ncc = new NhaCungCap();
            
            ncc.TenNhaCungCap = tenncc;
            ncc.DiaChi = diachi;
            ncc.SoDienThoai = sdt;
            if (aoe == "1")
            {
                qlncc.ThemMotNCC(ncc);
            }
            else
            {
                qlncc.CapNhatMotNCC(ncc);
            }
            return Redirect("~/QuanLyNCC/quanlynhacc");
        }
    }
}