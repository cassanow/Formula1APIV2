using Microsoft.EntityFrameworkCore;

namespace Formula1API_V2.Database;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

}