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
    
    public partial class FEATURES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FEATURES()
        {
            this.PRODUCT_FEATURES = new HashSet<PRODUCT_FEATURES>();
        }
    
        public int FEATURE_ID { get; set; }
        public string FEATURE_NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_FEATURES> PRODUCT_FEATURES { get; set; }
    }
}
