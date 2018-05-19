using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IA_Project.Models
{
    public class ProfessorModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "You have To enter User Name")]
        [Display(Name = "Your name")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "You have To enter Password")]
        [Display(Name = "Your Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "You have To enter image")]
        [Display(Name = "Your image")]
        public byte[] image { get; set; }

        [Required(ErrorMessage = "You have To enter Phone Number")]
        [Display(Name = "Your Phone Number")]
        public Nullable<decimal> phone_number { get; set; }

        [Required(ErrorMessage = "You have To enter Email")]
        [Display(Name = "Your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have To enter Department")]
        [Display(Name = "Your Department")]
        public string Department { get; set; }
    }
}