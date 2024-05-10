using HeseTazegi.Domain.Foods.Services;
using HeseTazegi.Domain.Ingredients;
using HeseTazegi.Domain.Ingredients.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HeseTazegi.Domain.Tests.Fixtures.Ingredients
{
    public class IngredientFactory
    {
        protected readonly Mock<IIngredientNameDuplicationChecker> mockIngredientNameDuplicationChecker = new();
        protected Ingredient CreateIngredient(string name = "Felfel", bool isFoodAllergen = false)
        {
            return new Ingredient(name, isFoodAllergen, mockIngredientNameDuplicationChecker.Object);
        }

        [TestInitialize]
        protected void Setup()
        {
            CallIngredientNameDuplicationChecker(false);
        }

        protected void CallIngredientNameDuplicationChecker(bool expectedResult)
        {
            mockIngredientNameDuplicationChecker.Setup(name =>
                    name.IsDuplicated(It.IsAny<string>())).Returns(expectedResult);
        }
    }
}
