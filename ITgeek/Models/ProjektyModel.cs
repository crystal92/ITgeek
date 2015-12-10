using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;


namespace ITgeek.Models

{
    
    public class DodajProjektViewModel
    {
        


        //public int id_projekt { get; set; }
        //public int id_uzytkownik { get; set; }
        //public string wstep { get; set; }
        //public int poziom_ukonczenia { get; set; }
        //public string uwagi_problemy { get; set; }
 
        // [System.Web.Mvc.Remote("czy_istnieje", "kontoController", HttpMethod = "POST", ErrorMessage = "E-mail został wykorzystywany.")]

        

        [Required]
        [Display(Name = "Nazwa Projektu")]
        public string nazwa_projektu { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Wstęp")]
        public string wstep { get; set; }

        [Required]
        [Display(Name = "Poziom ukończenia")]
        public int poziom_ukonczenia { get; set; }

        [Required]
        [Display(Name = "Użytkownik")]
        public int id_uzytkownik { get; set; }
      
    }

   


}
