using Formula1API_V2.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1API_V2.Database;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
    
    public DbSet<Piloto> Piloto { get; set; }

    public DbSet<Construtor> Construtor { get; set; }
    
    public DbSet<Pista> Pista { get; set; }
}