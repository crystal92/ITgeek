using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;





namespace ITgeek.Models
{
       public class RejestracjaViewModel
        {
            [Required]
            [Display(Name = "E-mail")]
           // [System.Web.Mvc.Remote("czy_istnieje", "kontoController", HttpMethod = "POST", ErrorMessage = "E-mail został wykorzystywany.")]
            public string email { get; set; }

            [Required]
            [Display(Name = "Użytkownik")]
            public string wyswietlana_nazwa { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string haslo { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź Hasło")]
            [Compare("haslo", ErrorMessage = "Hasła muszą być takie same")]
            public string powtorz_haslo { get; set; }
        }

       public class LogujViewModel
       {
           
           [Required]
           [Display(Name = "E-mail")]
           public string email { get; set; }

           [Required]
           [StringLength(100, ErrorMessage = "Login lub hasło są nieprawidłowe.", MinimumLength = 6)]
           [DataType(DataType.Password)]
           [Display(Name = "Hasło")]
           public string haslo { get; set; }

       }
    }
