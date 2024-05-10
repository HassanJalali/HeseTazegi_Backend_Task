using HeseTazegi.Domain.Foods.Services;
using HeseTazegi.Domain.Ingredients.Services;

namespace HeseTazegi.Domain.Services.Ingredients
{
    public class IngredientNameDuplicationChecker: IIngredientNameDuplicationChecker
    {
        private readonly IIngredientRepository _repository;

        public IngredientNameDuplicationChecker(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public bool IsDuplicated(string name)
        {
            return _repository.IsAny(ingredient => ingredient.Name == name);
        }
    }
}
