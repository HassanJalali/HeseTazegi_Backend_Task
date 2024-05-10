using Framework.Core.Persistence;
using Framework.Persistence;
using HeseTazegi.Domain.Ingredients;
using HeseTazegi.Domain.Ingredients.Services;

namespace HeseTazegi.Persistence.Ingredients
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(IDbContext context) : base(context)
        {
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            Create(ingredient);
        }

        public bool IsAny(Func<Ingredient, bool> predicate)
        {
            return dbContext.Set<Ingredient>().Any(predicate);
        }
    }
}
