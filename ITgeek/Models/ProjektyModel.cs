using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

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
        /*
        [Required]
        [Display(Name = "Uwagi")]
        public string uwagi_problemy { get; set; }

        [Required]
        [Display(Name = "Rozwinięcie")]
        public string rozwiniecie { get; set; }

        [Required]
        [Display(Name = "Zakończenie")]
        public string zakonczenie { get; set; }
        */
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
        public Komentarz Komentarz { get; set; }
        public Kategoria Kategoria { get; set; }
       // public List<PozycjaKategorii> kategorie { get; set; }
        public List<int> ID_kat { get; set; }
        public PozycjaKategorii PozycjaKategorii { get; set; }
        public List<komentarz> ListaKomentarzy { get; set; }
        public List<kategoria> ListaKategorii { get; set; }
        public List<pozycja_kategorii> ListaPozycjiKategorii { get; set; }
    }
}
