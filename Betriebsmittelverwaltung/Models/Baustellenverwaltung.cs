using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Betriebsmittelverwaltung.Models
{
    public class Baustellenverwaltung
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string kurzname { get; set; }
        [Display(Name = "Beschreibung")]
        public string beschreibung { get; set; }
    }
}