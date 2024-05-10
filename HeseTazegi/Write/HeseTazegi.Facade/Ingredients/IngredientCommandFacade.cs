using Framework.Facade;
using HeseTazegi.Application.Contracts.Ingredients;
using HeseTazegi.Facade.Contracts.Ingredients;
using MediatR;

namespace HeseTazegi.Facade.Ingredients
{
    public class IngredientCommandFacade : CommandFacadeBase, IIngredientCommandFacade
    {
        public IngredientCommandFacade(IMediator mediator) : base(mediator) { }
       
        public async Task CreateIngredient(CreateIngredientCommand command) => await mediator.Send(command);
    }
}
