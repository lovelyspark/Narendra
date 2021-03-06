using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Narendra.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Username is Required")]
        [Display(Name="Username")]
        [StringLength(50)]
        [MaxLength(50)]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(20)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmpassword")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }



        [Range(typeof(bool), "true", "true", ErrorMessage = "Please agree the terms and conditions")]
        [Display(Name = "Terms and Conditions")]
        public bool IsActive { get; set; }

        
        [Display(Name = "FullName")]
        [StringLength(20)]
        [MaxLength(20)]
        public string Admin { get; set; }

       
        [Display(Name ="FullName")]
        [StringLength(20)]
        [MaxLength(20)]
        public string Invigiltor { get; set; }

    }
}