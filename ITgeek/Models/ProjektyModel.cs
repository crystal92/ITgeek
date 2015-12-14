using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using ITgeek.Models;

namespace ITgeek.Models
{
    public class Projekt
    {
        [Required]
        [Display(Name = "Id projektu")]
        public int id_projekt { get; set; }
      
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

    public class Projekty
    {
        public Projekt Projekt { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}
