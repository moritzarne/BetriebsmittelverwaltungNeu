using Microsoft.EntityFrameworkCore;
using System;

namespace Betriebsmittelverwaltung.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Baustellenverwaltung> Baustellenverwaltung { get; set; }
        public DbSet<Bestandsverwaltung> Bestandsverwaltung { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    }

    
}