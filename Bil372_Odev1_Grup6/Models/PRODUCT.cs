//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bil372_Odev1_Grup6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.PRODUCT_BRANDS = new HashSet<PRODUCT_BRANDS>();
            this.PRODUCT_FEATURES = new HashSet<PRODUCT_FEATURES>();
        }
    
        public int M_SYSCODE { get; set; }
        public string M_CODE { get; set; }
        public string M_NAME { get; set; }
        public string M_SHORTNAME { get; set; }
        public string M_PARENTCODE { get; set; }
        public bool M_ABSTRACT { get; set; }
        public string M_CATEGORY { get; set; }
        public bool IS_ACTIVE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_BRANDS> PRODUCT_BRANDS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_FEATURES> PRODUCT_FEATURES { get; set; }
    }
}
