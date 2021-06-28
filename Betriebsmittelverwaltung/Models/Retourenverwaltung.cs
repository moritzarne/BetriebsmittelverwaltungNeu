using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Betriebsmittelverwaltung.Models
{
    public class Retourenverwaltung
    {
        public int Id { get; set; }
        public Typen Typ { get; set; }
        [Display(Name = "Baustellen ID")]
        public int BaustellenID { get; set; }
        [Display(Name = "Typ ID")]
        public int TypId { get; set; }
    }
}