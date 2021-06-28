using Microsoft.EntityFrameworkCore;
using System;
using Betriebsmittelverwaltung.Models;

namespace Betriebsmittelverwaltung.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Baustellenverwaltung> Baustellenverwaltung { get; set; }
        public DbSet<Bestandsverwaltung> Bestandsverwaltung { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Betriebsmittelverwaltung.Models.Auftragsverwaltung> Auftragsverwaltung { get; set; }
        public DbSet<Betriebsmittelverwaltung.Models.Retourenverwaltung> Retourenverwaltung { get; set; }
    }

    
}