//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyThoiKhoaBieu.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanCongGiangDay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanCongGiangDay()
        {
            this.DangKies = new HashSet<DangKy>();
            this.ThoiKhoaBieux = new HashSet<ThoiKhoaBieu>();
        }
    
        public int maPCGD { get; set; }
        public Nullable<int> maHP { get; set; }
        public Nullable<int> maGV { get; set; }
        public Nullable<int> maHK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKy> DangKies { get; set; }
        public virtual GiangVien GiangVien { get; set; }
        public virtual HocKy_NienKhoa HocKy_NienKhoa { get; set; }
        public virtual HocPhan HocPhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
    }
}