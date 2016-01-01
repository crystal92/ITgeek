using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ITgeek.Models
{
    public class Kategoria
    {
        [Required]
        [Display(Name = "Nazwa kategorii")]
        public string nazwa_kategorii { get; set; }
        
        [Required]
        [Display(Name = "Id kategorii")]
        public int id_kategoria { get; set; }
    }
}
