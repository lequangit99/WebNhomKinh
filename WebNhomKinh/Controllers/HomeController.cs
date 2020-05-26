using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNhomKinh.Models;

namespace WebNhomKinh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ShopEntities shop = new ShopEntities();
            ViewData["SanPhamMoi"] = shop.SanPhams.Where(s=>s.DacBiet==false).OrderByDescending(c => c.MaSanPham).Skip(0).Take(12).ToList();

            ViewData["SanPhamDacSac"] = shop.SanPhams.Where(c=>c.DacBiet==true).OrderByDescending(c => c.MaSanPham ).Skip(0).Take(12).ToList();
            ViewData["TinMoiNhat"] = shop.TinTucs.OrderByDescending(t => t.MaTinTuc).Skip(0).Take(4).ToList();
            ViewData["DanhSachChuyenMuc"] =
                shop.ChuyenMucs.Where(c => c.MaChuyenMucCha == null && c.DacBiet == false)
                    .OrderByDescending(c => c.MaChuyenMuc)
                    .ToList();
            ViewData["CongTrinhNoiBat"] = shop.CongTrinhNoiBats
                .OrderBy(c => c.MaCT)
                .Skip(0)
                .Take(12)
                .ToList();
            ViewData["PhuKien"] = shop.SanPhams
                .Include(s => s.ChuyenMuc)
                .Where(s => s.ChuyenMuc.TenChuyenMuc.ToLower().Contains("phụ kiện"))
                .ToList();
            ViewData["CuaBossDoor"] = shop.SanPhams
                .Include(s => s.ChuyenMuc)
                .Where(s => s.ChuyenMuc.MaChuyenMucCha==2)
                .OrderByDescending(s=>s.MaSanPham)
                .Skip(0)
                .Take(12)
                .ToList();
            ViewData["CuaAutsDoor"] = shop.SanPhams
                .Include(s => s.ChuyenMuc)
                .Where(s => s.ChuyenMuc.MaChuyenMucCha == 1)
                .OrderByDescending(s => s.MaSanPham)
                .Skip(0)
                .Take(12)
                .ToList();
            ViewData["CuaKinhNhom"] = shop.SanPhams
                .Include(s => s.ChuyenMuc)
                .Where(s => s.ChuyenMuc.MaChuyenMucCha == 5)
                .OrderByDescending(s => s.MaSanPham)
                .Skip(0)
                .Take(12)
                .ToList();
            ViewData["CuaKinhCuongLuc"] = shop.SanPhams
                .Include(s => s.ChuyenMuc)
                .Where(s => s.MaChuyenMuc==20)
                .OrderByDescending(s => s.MaSanPham)
                .Skip(0)
                .Take(12)
                .ToList();
            ViewData["SanPhamGiamGia"] = shop.SanPhams
                .Where(s => s.GiaGiam != 0)
                .OrderByDescending(s => s.MaSanPham)
                .Skip(0)
                .Take(3)
                .ToList();
            return View();
        }
        public ActionResult TimKiem(string q,int machuyenmuc)
        {
           
            ShopEntities shop = new ShopEntities();
            var dsChuyenMuc= shop.ChuyenMucs.Where(p =>p.MaChuyenMucCha == machuyenmuc).ToList();
            //var list=new List<SanPham>();
            //foreach (var item in dsChuyenMuc)
            //{
            //    list.AddRange(shop.SanPhams.Where(s=>s.TenSanPham.Contains(q) && s.MaChuyenMuc==item.MaChuyenMuc).ToList());
            //}
            //ViewData["DanhSachSanPham"] = list;
            ViewData["DanhSachSanPham"] = shop.SanPhams.Where(s => s.TenSanPham.Contains(q)).ToList();
            return View();
        }

    }
}