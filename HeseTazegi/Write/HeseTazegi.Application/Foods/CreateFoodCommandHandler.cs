using Framework.ApplicationService;
using HeseTazegi.Application.Contracts.Foods;
using HeseTazegi.Domain.Foods;
using HeseTazegi.Domain.Foods.Services;

namespace HeseTazegi.Application.Foods
{
    public class CreateFoodCommandHandler : ICommandHandler<CreateFoodCommand>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodNameDuplicationChecker _foodNameDuplicationChecker;
        private readonly IIngredientExistenceChecker _ingredientExistenceChecker;

        public CreateFoodCommandHandler(IFoodRepository foodRepository,
            IFoodNameDuplicationChecker foodNameDuplicationChecker,
            IIngredientExistenceChecker ingredientExistenceChecker)
        {
            _foodRepository = foodRepository;
            _foodNameDuplicationChecker = foodNameDuplicationChecker;
            _ingredientExistenceChecker = ingredientExistenceChecker;
        }
        public async Task Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = new Food(request.Name, request.IngredientIds,
                _foodNameDuplicationChecker, _ingredientExistenceChecker);

            _foodRepository.CreateFood(food);
        }
    }
}
