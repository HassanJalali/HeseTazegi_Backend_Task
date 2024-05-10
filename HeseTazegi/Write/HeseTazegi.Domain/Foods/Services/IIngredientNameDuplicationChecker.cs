using Framework.Core.Domain;

namespace HeseTazegi.Domain.Foods.Services
{
    public interface IFoodNameDuplicationChecker : IDomainService
    {
        bool IsDuplicated(string name);
    }
}
