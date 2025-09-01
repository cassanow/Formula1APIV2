using Formula1API_V2.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace Formula1Test.Data;

public class DatabaseFixture 
{
    public Context CreateContext()
    {
        var sqliteConnection = new SqliteConnection("DataSource=:memory:");
       sqliteConnection.Open();

       var options = new DbContextOptionsBuilder<Context>()
           .UseSqlite(sqliteConnection)
           .Options;
       
       var context = new Context(options);
       context.Database.EnsureCreated();
       
       return context;
   }
    
}