//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebNhomKinh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHoaDonNhap
    {
        public int Id { get; set; }
        public Nullable<int> MaHoaDon { get; set; }
        public Nullable<int> MaSanPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<decimal> GiaNhap { get; set; }
        public Nullable<decimal> TongTien { get; set; }
    
        public virtual HoaDonNhap HoaDonNhap { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}