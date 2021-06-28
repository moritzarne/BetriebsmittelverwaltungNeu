using Microsoft.EntityFrameworkCore;
using System;

namespace Betriebsmittelverwaltung.Models
{
    public class Auftragsverwaltung
    {
        public int Id { get; set; }
        public Typen Typ { get; set; }
        public int BaustellenID { get; set; }
    }
}