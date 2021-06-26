using Microsoft.EntityFrameworkCore;
using System;

namespace Betriebsmittelverwaltung.Models
{
    public class Baustellenverwaltung
    {
        public int Id { get; set; }
        public string kurzname { get; set; }
        public string beschreibung { get; set; }
    }
}