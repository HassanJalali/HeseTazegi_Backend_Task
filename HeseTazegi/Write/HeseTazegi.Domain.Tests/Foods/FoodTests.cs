using FluentAssertions;
using HeseTazegi.Domain.Foods.Exceptions;
using HeseTazegi.Domain.Tests.Fixtures.Foods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NameIsRequiredException = HeseTazegi.Domain.Foods.Exceptions.NameIsRequiredException;

namespace HeseTazegi.Domain.Tests.Foods
{
    [TestClass]
    public class FoodTests : FoodFactory
    {
        [TestMethod, TestCategory("Name")]
        [ExpectedException(typeof(NameIsRequiredException))]
        [DataRow("")]
        [DataRow("  ")]
        public void Name_Is_Required(string name)
        {
            CreateFood(name);
        }

        [TestMethod, TestCategory("Name")]
        [ExpectedException(typeof(NameCanNotBeDuplicatedException))]
        public void Name_Can_Not_Be_Duplicated()
        {
            CallFoodNameDuplicationChecker(true);
            CreateFood(name: "Felafel");
        }

        [TestMethod, TestCategory("Name")]
        [DataRow("Kabab_Tabeei")]
        [DataRow("Mahi_Kababi")]
        public void Name_Retrive(string name)
        {
            CallIngredientExistenceCheck(true);
            var food = CreateFood(name);
            food.Name.Should().Be(name);
        }

        [TestMethod, TestCategory("Ingredient")]
        [ExpectedException(typeof(IngredientIsReuqiredException))]
        public void Food_Must_Contain_At_Least_One_Ingredient()
        {
            var emptyIngredientIdList = new List<Guid>();
            CreateFood(isIngredientIdsRequired: false, ingredientIds: emptyIngredientIdList);
        }

        [TestMethod, TestCategory("Ingredient")]
        [ExpectedException(typeof(IngredientsAreNotValidException))]
        public void Ingredient_Must_Be_Valid()
        {
            var ingredients = GetIngredient(5);
            CallIngredientExistenceCheck(false);
            CreateFood(isIngredientIdsRequired: false, ingredientIds: ingredients.Item1);
        }

        [TestMethod, TestCategory("Ingredient")]
        public void Ingredient_Retrive()
        {
            CallIngredientExistenceCheck(true);
            var ingredients = GetIngredient(5);
            var food = CreateFood(isIngredientIdsRequired: false, ingredientIds: ingredients.Item1);

            food.Ingredients.Should().NotBeEmpty();
            food.Ingredients.Should().HaveSameCount(ingredients.Item2);
        }
    }
}
