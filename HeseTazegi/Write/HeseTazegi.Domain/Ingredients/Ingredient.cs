using Framework.Core.Domain;
using Framework.Domain;
using HeseTazegi.Domain.Foods.Services;
using HeseTazegi.Domain.Ingredients.Exceptions;
using HeseTazegi.Domain.Ingredients.Services;

namespace HeseTazegi.Domain.Ingredients
{
    public class Ingredient : BaseEntity, IAggregateRoot
    {
        public Ingredient(string name, bool isFoodAllergen, IIngredientNameDuplicationChecker nameDuplicationChecker)
        {
            SetName(name, nameDuplicationChecker);
            IsFoodAllergen = isFoodAllergen;
        }

        private Ingredient() { }

        public string Name { get; private set; }
        public bool IsFoodAllergen { get; private set; }


        private void SetName(string name, IIngredientNameDuplicationChecker nameDuplicationChecker)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NameIsRequiredException();

            if (nameDuplicationChecker.IsDuplicated(name))
                throw new NameCanNotBeDuplicatedException();

            Name = name;
        }
    }
}
