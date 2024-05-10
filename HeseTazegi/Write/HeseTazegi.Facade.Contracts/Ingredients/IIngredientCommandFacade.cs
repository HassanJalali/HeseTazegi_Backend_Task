using Framework.Core.Facade;
using HeseTazegi.Application.Contracts.Ingredients;

namespace HeseTazegi.Facade.Contracts.Ingredients
{
    public interface IIngredientCommandFacade : ICommandFacade
    {
        Task CreateIngredient(CreateIngredientCommand command);
    }
}
