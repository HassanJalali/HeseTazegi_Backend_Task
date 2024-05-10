using Framework.Facade;
using HeseTazegi.Application.Contracts.Foods;
using HeseTazegi.Facade.Contracts.Foods;
using MediatR;

namespace HeseTazegi.Facade.Foods
{
    public class FoodCommandFacade : CommandFacadeBase, IFoodCommandFacade
    {
        public FoodCommandFacade(IMediator mediator) : base(mediator) { }

        public async Task CreateFood(CreateFoodCommand command) => await mediator.Send(command);
    }
}
