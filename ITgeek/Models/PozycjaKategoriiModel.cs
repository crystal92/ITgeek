using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ITgeek.Models
{

    public class PozycjaKategorii
    {
        [Required]
        [Display(Name = "Id pozycji kategorii")]
        public int id_pozycja_kategorii { get; set; }
      
        [Required]
        [Display(Name = "Id projektu")]
        public int id_projekt { get; set; }
        
        [Required]
        [Display(Name = "Id kategorii")]
        public int id_kategoria { get; set; }
    }
}
