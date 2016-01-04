using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ITgeek.Models
{

    public class OcenaProjektu
    {
        [Required]
        [Display(Name = "Id oceny projektu")]
        public int id_ocena_projektu { get; set; }
      
        [Required]
        [Display(Name = "Id projektu")]
        public int id_projekt { get; set; }
        
        [Required]
        [Display(Name = "Ocena projektu")]
        public int ocena_projektu1 { get; set; }
        
        [Required]
        [Display(Name = "Id Użytkownik")]
        public int id_uzytkownik { get; set; }
          
    }
}
