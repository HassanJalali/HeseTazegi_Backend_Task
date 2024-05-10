using Framework.ApplicationService;

namespace HeseTazegi.Application.Contracts.Ingredients
{
    public class CreateIngredientCommand : Command
    {
        public string Name { get; set; }
        public bool IsFoodAllergen { get; set; }
    }
}
