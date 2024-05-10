using Framework.ApplicationService;

namespace HeseTazegi.Application.Contracts.Foods
{
    public class CreateFoodCommand : Command
    {
        public string Name { get; set; }
        public List<Guid> IngredientIds { get; set; }
    }
}
