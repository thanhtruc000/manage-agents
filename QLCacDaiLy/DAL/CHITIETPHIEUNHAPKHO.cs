//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLCacDaiLy.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETPHIEUNHAPKHO
    {
        public string MAHANGHOA { get; set; }
        public string MAPHIEUNHAPKHO { get; set; }
        public int SOLUONGNHAP { get; set; }
        public double SOTIENCHI { get; set; }
    
        public virtual HANGHOA HANGHOA { get; set; }
        public virtual PHIEUNHAPKHO PHIEUNHAPKHO { get; set; }
    }
}
