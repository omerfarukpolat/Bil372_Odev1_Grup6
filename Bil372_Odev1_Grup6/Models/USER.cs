using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bil372_Odev1_Grup6.Models
{
    public class USER
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "This field cannot be empty")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field cannot be empty")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}