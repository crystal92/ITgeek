using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using System.Collections.Generic;


namespace ITgeek.Models
{
    public class Komentarz
    {
        [Required]
        [Display(Name = "Id komentarzu")]
        public int id_komentarz { get; set; }
      
        [Required]
        [Display(Name = "Id użytkownika")]
        public int id_uzytkownik { get; set; }

        [Required]
        [Display(Name = "Komentarz")]
        public string tresc_komentarza { get; set; }

        [Required]
        [Display(Name = "Id projektu")]
        public int id_projekt { get; set; }        
    }
}
