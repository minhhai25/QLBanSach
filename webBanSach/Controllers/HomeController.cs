using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webBanSach.Models;
using X.PagedList;

namespace webBanSach.Controllers
{
    public class HomeController : Controller
    {
        WebqlbansachContext db = new WebqlbansachContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.Sanphams.AsNoTracking().OrderBy(x => x.Tensp);
            PagedList<Sanpham> lst = new PagedList<Sanpham>(lstSanPham, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            //  ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "MaTh", "TenTh");
            ViewBag.Manxb = new SelectList(db.Nxbs.ToList(), "Manxb", "Tennxb");
            ViewBag.Maloai = new SelectList(db.Loais.ToList(), "Maloai", "Tenloai");
            ViewBag.Matg = new SelectList(db.Tacgia.ToList(), "Matg", "Tentg");

            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Sanpham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Sanphams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }




        [Route("danhmucdondat")]
        public IActionResult DanhMucDonDat(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstDonDat = db.Dondats.AsNoTracking().OrderBy(x => x.Madd);
            PagedList<Dondat> lst = new PagedList<Dondat>(lstDonDat, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemDonDatMoi")]
        [HttpGet]
        public IActionResult ThemDonDatMoi()
        {
            //  ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "MaTh", "TenTh");
            ViewBag.Madd = new SelectList(db.Dondats.ToList(), "Madd", "Thoigian");
            ViewBag.Matk = new SelectList(db.Taikhoans.ToList(), "Matk", "Tendn");

            return View();
        }
        [Route("ThemDonDatMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemDonDatMoi(Dondat dondat)
        {
            if (ModelState.IsValid)
            {
                db.Dondats.Add(dondat);
                db.SaveChanges();
                return RedirectToAction("DanhMucDonDat");
            }
            return View(dondat);
        }




        [Route("danhmucchitietdd")]
        public IActionResult DanhMucChiTietDD(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstChiTietDD = db.Ctdds.AsNoTracking().OrderBy(x => x.Mactdd);
            PagedList<Ctdd> lst = new PagedList<Ctdd>(lstChiTietDD, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemChiTietDDMoi")]
        [HttpGet]
        public IActionResult ThemChiTietDDMoi()
        {
            //  ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "MaTh", "TenTh");
            ViewBag.Masp = new SelectList(db.Sanphams.ToList(), "Masp", "Tensp");
            ViewBag.Madd = new SelectList(db.Dondats.ToList(), "Madd", "Matk");


            return View();
        }
        [Route("ThemChiTietDDMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemChiTietDDMoi(Ctdd chitietdd)
        {
            if (ModelState.IsValid)
            {
                db.Ctdds.Add(chitietdd);
                db.SaveChanges();
                return RedirectToAction("DanhMucChiTietDD");
            }
            return View(chitietdd);
        }
    }
}
