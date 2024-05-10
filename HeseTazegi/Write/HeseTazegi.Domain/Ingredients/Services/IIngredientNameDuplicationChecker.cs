using Framework.Core.Domain;

namespace HeseTazegi.Domain.Ingredients.Services
{
    public interface IIngredientNameDuplicationChecker : IDomainService
    {
        bool IsDuplicated(string name);
    }
}
