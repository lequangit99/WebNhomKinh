//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopBanDoTheThao.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhap()
        {
            this.ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }
    
        public int MaHoaDon { get; set; }
        public Nullable<int> MaNhaPhanPhoi { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string KieuThanhToan { get; set; }
        public Nullable<int> MaTaiKhoan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual NhaPhanPhois NhaPhanPhois { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
