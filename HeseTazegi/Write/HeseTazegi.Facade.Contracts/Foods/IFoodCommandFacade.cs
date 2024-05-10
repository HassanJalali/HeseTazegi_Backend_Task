using Framework.Core.Facade;
using HeseTazegi.Application.Contracts.Foods;

namespace HeseTazegi.Facade.Contracts.Foods
{
    public interface IFoodCommandFacade : ICommandFacade
    {
        Task CreateFood(CreateFoodCommand command);
    }
}
