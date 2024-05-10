using HeseTazegi.Domain.Foods.Services;
using HeseTazegi.Domain.Ingredients.Services;

namespace HeseTazegi.Domain.Services.Foods
{
    public class IngredientExistenceChecker : IIngredientExistenceChecker
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientExistenceChecker(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public bool IsExist(List<Guid> ingredientIds)
        {
            var areExist = new List<bool>();
            foreach (var ingredientId in ingredientIds)
            {
                var isExist = _ingredientRepository.IsAny(i => i.Id == ingredientId);
                areExist.Add(isExist);
            }

            if (areExist.All(i => i == true))
            {
                return true;
            }

            return false;
        }
    }
}
