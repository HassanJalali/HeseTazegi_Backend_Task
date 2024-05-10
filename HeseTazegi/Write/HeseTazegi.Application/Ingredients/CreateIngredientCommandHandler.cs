using Framework.ApplicationService;
using HeseTazegi.Application.Contracts.Ingredients;
using HeseTazegi.Domain.Foods.Services;
using HeseTazegi.Domain.Ingredients;
using HeseTazegi.Domain.Ingredients.Services;

namespace HeseTazegi.Application.Ingredients
{
    public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
    {
        private readonly IIngredientRepository _repository;
        private readonly IIngredientNameDuplicationChecker _duplicationChecker;

        public CreateIngredientCommandHandler(IIngredientRepository repository,
            IIngredientNameDuplicationChecker duplicationChecker)
        {
            _repository = repository;
            _duplicationChecker = duplicationChecker;
        }

        public async Task Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Name, request.IsFoodAllergen, _duplicationChecker);
            _repository.CreateIngredient(ingredient);
        }
    }
}
