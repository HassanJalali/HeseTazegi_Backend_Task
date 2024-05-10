using Framework.Persistence;
using HeseTazegi.Persistence.Ingredients.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HeseTazegi.Database
{
    public class HeseTazegiDbContext : BaseDbContext
    {
        public HeseTazegiDbContext(DbContextOptions<HeseTazegiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientMapping).Assembly);
        }
    }
}
