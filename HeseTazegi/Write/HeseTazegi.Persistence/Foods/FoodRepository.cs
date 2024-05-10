using Framework.Core.Persistence;
using Framework.Persistence;
using HeseTazegi.Domain.Foods;
using HeseTazegi.Domain.Foods.Services;

namespace HeseTazegi.Persistence.Foods
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(IDbContext context) : base(context)
        {
        }

        public void CreateFood(Food food)
        {
            base.Create(food);
        }

        public bool IsAny(Func<Food, bool> predicated)
        {
            return dbContext.Set<Food>().Any(predicated);
        }

    }
}
