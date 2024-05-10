using Framework.Core.Domain;

namespace HeseTazegi.Domain.Foods.Services
{
    public interface IIngredientExistenceChecker : IDomainService
    {
        bool IsExist(List<Guid> ingredientIds);
    }
}
