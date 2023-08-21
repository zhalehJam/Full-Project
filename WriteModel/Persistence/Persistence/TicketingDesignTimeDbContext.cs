using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace  Persistence
{
    public class TicketingDesignTimeDbContext : IDesignTimeDbContextFactory<TicketingDbContext>
    {
        public TicketingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TicketingDbContext>();
 
            optionsBuilder.UseSqlServer("Server =.,1433; Database = TicketingDeveloper; user id=sa;password=123qaz!@#; ");
 
            //optionsBuilder.UseSqlServer("Server =Ticketing_DB; Database = Ticketing; user id=sa;password=123qaz!@#");
 

            return new TicketingDbContext(optionsBuilder.Options);
        }
    }
}
