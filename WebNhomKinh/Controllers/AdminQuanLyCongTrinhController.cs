using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using WebNhomKinh.Models;

namespace WebNhomKinh.Controllers
{
    public class AdminQuanLyCongTrinhController : Controller
    {
        // GET: AdminQuanLyCongTrinh
       
        private static int maCongTrinh = 0;
       
        [HttpGet]
        public ActionResult Index(string searchString, int? page)
        {
            if (Session["MaTKAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                try
                {
                    QuanLyCongTrinh model = new QuanLyCongTrinh()
                    {
                        DanhSachCongTrinh = KhoiTao(searchString, page)
                    };
                    return View(model);
                }
                catch (Exception)
                {

                    return RedirectToAction("Index");
                }

            }

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemCongTrinh(QuanLyCongTrinh qlct, HttpPostedFileBase file, string submit, int MaCT, string hdimg)
        {
            if (Session["MaTKAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                try
                {
                    ShopEntities shop = new ShopEntities();
                    if (submit == "Thêm")
                    {

                        file = file ?? Request.Files["file"];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            if (fileName != null)
                            {
                                var path = Path.Combine(Server.MapPath("~/Images/Products/cong-trinh/"), fileName);
                                file.SaveAs(path);
                            }
                            CongTrinhNoiBat ct = new CongTrinhNoiBat();
                            ct.TenCT = qlct.CongTrinh.TenCT;
                            ct.AnhDaiDien = "~/Images/Products/cong-trinh/" + fileName;
                            ct.DiaChi = qlct.CongTrinh.DiaChi;
                            ct.Chitiet = qlct.CongTrinh.Chitiet;
                            ct.TrangThai = true;
                            shop.CongTrinhNoiBats.Add(ct);
                            shop.SaveChanges();
                        }
                    }
                    if (submit == "Sửa")
                    {
                        file = file ?? Request.Files["file"];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            if (fileName != null)
                            {
                                var path = Path.Combine(Server.MapPath("~/Images/Products/cong-trinh/"), fileName);
                                file.SaveAs(path);
                                var tt = shop.CongTrinhNoiBats.Single(s => s.MaCT == MaCT);
                                tt.TenCT = qlct.CongTrinh.TenCT;
                                tt.AnhDaiDien = "~/Images/Products/cong-trinh/" + fileName;
                                tt.DiaChi = qlct.CongTrinh.DiaChi;
                                tt.Chitiet = qlct.CongTrinh.Chitiet;
                                tt.TrangThai = true;
                                shop.SaveChanges();
                            }
                        }
                        else
                        {
                            var tt = shop.CongTrinhNoiBats.Single(s => s.MaCT == MaCT);
                            tt.TenCT = qlct.CongTrinh.TenCT;
                            tt.AnhDaiDien = hdimg;
                            tt.DiaChi = qlct.CongTrinh.DiaChi;
                            tt.Chitiet = qlct.CongTrinh.Chitiet;
                            tt.TrangThai = true;
                            shop.SaveChanges();
                        }

                    }
                    // KhoiTao();
                    
                    QuanLyCongTrinh model = new QuanLyCongTrinh()
                    {
                        DanhSachCongTrinh = KhoiTao("", 1)
                    };
                    return View("Index", model);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");

                }

            }

        }
        [HttpPost]
        public ActionResult XoaCongTrinh(int id)
        {
            if (Session["MaTKAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                try
                {
                    ShopEntities shop = new ShopEntities();
                    CongTrinhNoiBat congTrinh = shop.CongTrinhNoiBats.SingleOrDefault(t => t.MaCT == id);
                    shop.CongTrinhNoiBats.Remove(congTrinh);
                    shop.SaveChanges();
                    return Json(JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    return RedirectToAction("Index");
                }

            }

        }
        public IPagedList<CongTrinhNoiBat> KhoiTao(string searchString, int? page)
        {

            ViewBag.CurrentFilter = searchString;
            ShopEntities shop = new ShopEntities();
            var dsCongTrinh = shop.CongTrinhNoiBats.OrderBy(s => s.MaCT);
            if (!String.IsNullOrEmpty(searchString))
            {
                dsCongTrinh = shop.CongTrinhNoiBats.Where(s => s.TenCT.Contains(searchString)).OrderBy(s => s.MaCT);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            dsCongTrinh.ToPagedList(pageNumber, pageSize);
            return dsCongTrinh.ToPagedList(pageNumber, pageSize);
        }
        [HttpGet]
        public ActionResult LayCongTrinh(int maCongTrinh)
        {
            if (Session["MaTKAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                try
                {
                    ShopEntities shop = new ShopEntities();
                    JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

                    CongTrinhNoiBat tt = shop.CongTrinhNoiBats.Single(t => t.MaCT == maCongTrinh);
                    var result = JsonConvert.SerializeObject(tt, Formatting.Indented, jss);
                    return this.Json(result, JsonRequestBehavior.AllowGet); ;
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");

                }

            }

        }

    }
}