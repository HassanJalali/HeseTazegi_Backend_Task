using HeseTazegi.Domain.Foods;
using HeseTazegi.Domain.Foods.Services;
using HeseTazegi.Domain.Ingredients;
using HeseTazegi.Domain.Ingredients.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HeseTazegi.Domain.Tests.Fixtures.Foods
{
    public class FoodFactory
    {
        protected readonly Mock<IIngredientNameDuplicationChecker> mockIngredientNameDuplicationChecker = new();
        protected readonly Mock<IFoodNameDuplicationChecker> mockFoodNameDuplicationChecker = new();
        protected readonly Mock<IIngredientExistenceChecker> mockIngredientExistenceChecker = new();

        [TestInitialize]
        protected void Setup()
        {
            CallIngredientNameDuplicationChecker(false);
            CallFoodNameDuplicationChecker(false);
            CallIngredientExistenceCheck(true);
        }

        protected Food CreateFood(string name = "Felafel",
                        List<Guid> ingredientIds = null,
                        bool isIngredientIdsRequired = true)
        {
            var ingredient = GetIngredient();
            if (ingredientIds is null && isIngredientIdsRequired) ingredientIds = ingredient.Item1;
            return new Food(name, ingredientIds, mockFoodNameDuplicationChecker.Object,
                mockIngredientExistenceChecker.Object);
        }

        protected Ingredient CreateIngredient(string name = "Felfel", bool isFoodAllergen = false)
        {
            return new Ingredient(name, isFoodAllergen, mockIngredientNameDuplicationChecker.Object);
        }

        protected (List<Guid>, List<FoodIngredient>) GetIngredient(int ingredientNumber = 3)
        {
            var foodIngredients = new List<FoodIngredient>();
            var ingredientIds = new List<Guid>();

            for (int i = 0; i < ingredientNumber; i++)
            {
                var ingredient = CreateIngredient(name: $"Felafel{i}");
                var foodIngredient = new FoodIngredient
                {
                    IngredientId = ingredient.Id
                };

                foodIngredients.Add(foodIngredient);
                ingredientIds.Add(ingredient.Id);
            }

            return (ingredientIds, foodIngredients);
        }

        protected void CallIngredientNameDuplicationChecker(bool expectedResult)
        {
            mockIngredientNameDuplicationChecker.Setup(name =>
                  name.IsDuplicated(It.IsAny<string>())).Returns(expectedResult);
        }

        protected void CallFoodNameDuplicationChecker(bool expectedResult)
        {
            mockFoodNameDuplicationChecker.Setup(name =>
                    name.IsDuplicated(It.IsAny<string>())).Returns(expectedResult);
        }

        protected void CallIngredientExistenceCheck(bool expectedResult)
        {
            mockIngredientExistenceChecker.Setup(name =>
                    name.IsExist(It.IsAny<List<Guid>>())).Returns(expectedResult);
        }
    }
}
