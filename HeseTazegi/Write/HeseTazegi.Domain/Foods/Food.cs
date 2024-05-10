using Framework.Core.Domain;
using Framework.Domain;
using HeseTazegi.Domain.Foods.Exceptions;
using HeseTazegi.Domain.Foods.Services;

namespace HeseTazegi.Domain.Foods
{
    public class Food : BaseEntity, IAggregateRoot
    {
        public Food(string name, List<Guid> ingredientIds,
            IFoodNameDuplicationChecker foodNameDuplicationChecker,
            IIngredientExistenceChecker ingredientExistenceChecker)
        {
            SetName(name, foodNameDuplicationChecker);
            SetIngredient(ingredientIds, ingredientExistenceChecker);
        }

        private Food() { }

        public string Name { get; private set; }
        public List<FoodIngredient> Ingredients { get; private set; } = new();

        private void SetName(string name, IFoodNameDuplicationChecker foodNameDuplicationChecker)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NameIsRequiredException();

            if (foodNameDuplicationChecker.IsDuplicated(name))
                throw new NameCanNotBeDuplicatedException();

            Name = name;
        }
        private void SetIngredient(List<Guid> ingredientIds,
            IIngredientExistenceChecker ingredientExistenceChecker)
        {
            if (!ingredientIds.Any())
                throw new IngredientIsReuqiredException();

            if (!ingredientExistenceChecker.IsExist(ingredientIds))
                throw new IngredientsAreNotValidException();

            foreach (var ingredientId in ingredientIds)
            {
                Ingredients.Add(new FoodIngredient
                {
                    IngredientId = ingredientId
                });
            }
        }
    }
}
