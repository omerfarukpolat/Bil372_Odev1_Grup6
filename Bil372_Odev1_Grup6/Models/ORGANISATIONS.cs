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
    
    public partial class ORGANISATIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORGANISATIONS()
        {
            this.BRAND_ORGS = new HashSet<BRAND_ORGS>();
        }
    
        public int ORG_ID { get; set; }
        public string ORG_NAME { get; set; }
        public Nullable<int> PARENT_ORG { get; set; }
        public bool ORG_ABSTRACT { get; set; }
        public string ORG_ADDRESS { get; set; }
        public Nullable<int> ORG_CITY { get; set; }
        public Nullable<int> ORG_TYPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BRAND_ORGS> BRAND_ORGS { get; set; }
    }
}
