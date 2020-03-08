using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Correo electronico")]
        [StringLength(100,ErrorMessage ="Es muy largo el correo", MinimumLength =1)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar el password")]
        [Compare("Password",ErrorMessage ="No coinciden los password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }

    }

    public class EditUserViewModel
    {
        public int Id { get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electronico")]
        [StringLength(100, ErrorMessage = "Es muy largo el correo", MinimumLength = 1)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar el password")]
        [Compare("Password", ErrorMessage = "No coinciden los password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Edad { get; set; }

    }
}