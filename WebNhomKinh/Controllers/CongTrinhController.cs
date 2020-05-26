using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNhomKinh.Models;

namespace WebNhomKinh.Controllers
{
    public class CongTrinhController : Controller
    {
        // GET: CongTrinh
        public ActionResult Index()
        {
            ShopEntities shop = new ShopEntities();
            ViewData["DsCongTrinh"] = shop.CongTrinhNoiBats.OrderBy(t => t.MaCT).ToList();

            return View();
        }

        public ActionResult ChiTietCongTrinh(int id)
        {

            ShopEntities shop = new ShopEntities();
            var congtrinh = shop.CongTrinhNoiBats.SingleOrDefault(t => t.MaCT == id);
            if (congtrinh != null)
            {
                shop.SaveChanges();
                ViewData["CongTrinh"] = congtrinh;
            }
            return View();
        }
    }
}