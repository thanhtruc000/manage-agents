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
    
    public partial class PHIEUTHUTIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTHUTIEN()
        {
            this.BAOCAOTHUCHIs = new HashSet<BAOCAOTHUCHI>();
        }
    
        public string MAPHIEUTHUTIEN { get; set; }
        public System.DateTime NGAYTHUTIEN { get; set; }
        public double SOTIENTHU { get; set; }
        public string MADAILY { get; set; }
    
        public virtual DAILY DAILY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOCAOTHUCHI> BAOCAOTHUCHIs { get; set; }
    }
}
