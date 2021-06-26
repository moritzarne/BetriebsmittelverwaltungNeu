using Microsoft.EntityFrameworkCore;
using System;

namespace Betriebsmittelverwaltung.Models
{

    public enum Typen
    {
        Kran,
        Akkuschrauber,
        LKW,
        Schaufel,
        Bagger,
        Schraubendreher,
        Hammer,
        Helm,
        Zange,
        Absperrband
    }
    public class Bestandsverwaltung
    {
        public int Id { get; set; }
        public Typen Typ { get; set; }
        public DateTime Kaufdatum { get; set; }
        public int Wartungsintervall { get; set; }
    }
}