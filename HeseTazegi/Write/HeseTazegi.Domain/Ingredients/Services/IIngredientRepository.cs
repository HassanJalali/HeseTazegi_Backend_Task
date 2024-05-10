using Framework.Core.Persistence;

namespace HeseTazegi.Domain.Ingredients.Services
{
    public interface IIngredientRepository : IRepository
    {
        void CreateIngredient(Ingredient ingredient);
        bool IsAny(Func<Ingredient, bool> predicate);
    }
}
