using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn003.Models;
using DoAn003.Models.ListEntities;
using PagedList;

namespace DoAn003.Controllers.Clt
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        SanPhamModel qlsp = new SanPhamModel();
        WebCayCanhDB data = new WebCayCanhDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult timkiemtheoten(int? page, string kw)
        {
            var dssp = qlsp.DanhSachSanPham();
            List<SanPham> kq = new List<SanPham>();
            int pageSite = 8;
            int pagenumber = (page??1);
            var kqtk = data.SanPham.Where(m=>m.TenSanPham.Contains(kw)).ToList();
          
            ViewBag.tit = "có " + kqtk.Count + " sản phẩm có chứa "+"''"+kw+"''";
            return View(kqtk.ToPagedList(pagenumber, pageSite));
        }
    }
}