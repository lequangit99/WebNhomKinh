using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WebNhomKinh.Models
{
    public class QuanLySanPham


    {

        public IPagedList<SanPham> ListSanPham { get; set; }
        public SanPham SanPham { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
    }
}