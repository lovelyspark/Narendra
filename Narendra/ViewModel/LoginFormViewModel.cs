using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Xunit.Sdk;

namespace Narendra.ViewModel
{
    public class LoginFormViewModel
    {
   
        public string Admin;
        public string Invigiltor;


        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "Username")]
        [StringLength(50)]
        [MaxLength(50)]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(20)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}