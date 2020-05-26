using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNhomKinh.Models;

namespace WebNhomKinh.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
      
        public ActionResult Index()
        {
            ShopEntities shop=new ShopEntities();
            ViewData["DsTinTuc"] = shop.TinTucs.OrderBy(t=>t.MaTinTuc).ToList();
           
            return View();
        }

        public ActionResult ChiTietTinTuc(int id)
        {
           
            ShopEntities shop = new ShopEntities();
            var tintuc= shop.TinTucs.SingleOrDefault(t => t.MaTinTuc == id);
            if (tintuc != null)
            {
                tintuc.LuotXem += 1;
                shop.SaveChanges();
                ViewData["TinTuc"] = tintuc;
            }
            return View();
        }

       

       
    }
}