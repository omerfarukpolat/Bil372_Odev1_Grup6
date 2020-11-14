using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Odev1_Grup6.Models
{
    public class LINKINGPRODUCTFEATURES
    {
        public string M_CODE { get; set; }
        public string M_NAME { get; set; }
        public string M_CATEGORY { get; set; }
        public string FEATURE_NAME { get; set; }
        public float MINVAL { get; set; }
        public float MAXVAL { get; set; }
    }
}