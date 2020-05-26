using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WebNhomKinh.Models
{
    public class QuanLyChuyenMuc
    {
        public IPagedList<ChuyenMuc> DanhSachChuyenMuc { get; set; }
        public ChuyenMuc ChuyenMuc { get; set; }
    }
}