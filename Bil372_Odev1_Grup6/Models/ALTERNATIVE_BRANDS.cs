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
    
    public partial class ALTERNATIVE_BRANDS
    {
        public string BRAND_BARCODE { get; set; }
        public int M_SYSCODE { get; set; }
        public string ALTERNATIVE_BRAND_BARCODE { get; set; }
        public Nullable<int> ALTERNATIVE_M_SYSCODE { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }
        public virtual PRODUCT_BRANDS PRODUCT_BRANDS { get; set; }
        public virtual PRODUCT_BRANDS PRODUCT_BRANDS1 { get; set; }
    }
}
