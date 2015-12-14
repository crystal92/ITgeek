using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;




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

       public class Uzytkownik
       {

           [Required]
           [Display(Name = "Użytkownik")]
           public int id_uzytkownik { get; set; }

           [Required]
           [Display(Name = "Imię")]
           public string imie { get; set; }

           [Required]
           [Display(Name = "Nazwisko")]
           public string nazwisko { get; set; }

           [Required]
           [Display(Name = "E-mail")]
           public string email { get; set; }

           [Required]
           [Display(Name = "Użytkownik")]
           public string wyswietlana_nazwa { get; set; }

           [Required]
           [Display(Name = "Data urodzenia")]
           [DataType(DataType.Date)]
           [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
           public DateTime? data_urodzenia { get; set; }

           [Required]
           [Display(Name = "Miejscowość")]
           public string miejscowosc { get; set; }

           [Required]
           [DataType(DataType.Password)]
           [Display(Name = "Hasło")]
           public string haslo { get; set; }

           [Required]
           [Display(Name = "Uprawnienia")]
           public string uprawnienia { get; set; }
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
