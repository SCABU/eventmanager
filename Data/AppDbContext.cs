using eventmanager.Models;
using Microsoft.EntityFrameworkCore;

namespace eventmanager.Data
{
    public class AppDbContext : DbContext
    {
        //il costruttore vuoto serve per dare l'opzione di memorizzazione del database (in memory, mysql, sqllight)
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


        //Dichiarare un numero di liste pari al numero di tabelle del database che si intendono usare
        public DbSet<champions> Champions{ get; set; }
        public DbSet<Rootobject> Competition { get; set; }
        public DbSet<rankings> Rankings { get; set; }
        public DbSet<competitor> Competitor { get; set; }
        
    }
}

