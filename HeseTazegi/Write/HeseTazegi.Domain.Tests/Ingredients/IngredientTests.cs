using FluentAssertions;
using HeseTazegi.Domain.Tests.Fixtures.Ingredients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NameCanNotBeDuplicatedException = HeseTazegi.Domain.Ingredients.Exceptions.NameCanNotBeDuplicatedException;
using NameIsRequiredException = HeseTazegi.Domain.Ingredients.Exceptions.NameIsRequiredException;

namespace HeseTazegi.Domain.Tests.Ingredients
{
    [TestClass]
    public class IngredientTests: IngredientFactory
    {
        [TestMethod, TestCategory("Name")]
        [ExpectedException(typeof(NameIsRequiredException))]
        [DataRow("")]
        [DataRow("  ")]
        public void Name_Is_Required(string name)
        {
            CreateIngredient(name);
        }

        [TestMethod, TestCategory("Name")]
        [ExpectedException(typeof(NameCanNotBeDuplicatedException))]
        public void Name_Can_Not_Be_Duplicated()
        {
            var existedIngredient = CreateIngredient();
            CallIngredientNameDuplicationChecker(true);
            CreateIngredient(name: existedIngredient.Name);
        }

        [TestMethod, TestCategory("Name")]
        [DataRow("Sir")]
        [DataRow("Felfel")]
        public void Name_Retrive(string name)
        {
            var ingredient = CreateIngredient(name);
            ingredient.Name.Should().Be(name);
        }

        [TestMethod, TestCategory("IsFoodAllergen")]
        public void IsFoodAllergen_Retrive()
        {
            var ingredient = CreateIngredient(isFoodAllergen: true);
            ingredient.IsFoodAllergen.Should().BeTrue();
        }
    }
}
