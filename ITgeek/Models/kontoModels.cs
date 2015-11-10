using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITgeek.Models
{
       public class RejestracjaViewModel
        {
            [Required]
            [Display(Name = "E-mail")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "Użytkownik")]
            public string ViewName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź Hasło")]
            [Compare("Password", ErrorMessage = "Hasła muszą być takie same")]
            public string ConfirmPassword { get; set; }
        }
    }
