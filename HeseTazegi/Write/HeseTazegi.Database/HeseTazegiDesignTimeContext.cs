using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HeseTazegi.Database
{
    public class HeseTazegiDesignTimeContext : IDesignTimeDbContextFactory<HeseTazegiDbContext>
    {
        public HeseTazegiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HeseTazegiDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=HeseTazegi;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True");


            return new HeseTazegiDbContext(optionsBuilder.Options);
        }
    }
}
