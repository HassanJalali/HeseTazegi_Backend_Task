using HeseTazegi.Domain.Foods.Services;

namespace HeseTazegi.Domain.Services.Foods
{
    public class FoodNameDuplicationChecker : IFoodNameDuplicationChecker
    {
        private readonly IFoodRepository _repository;

        public FoodNameDuplicationChecker(IFoodRepository repository)
        {
            _repository = repository;
        }
        public bool IsDuplicated(string name)
        {
            return _repository.IsAny(food => food.Name == name);
        }
    }
}
