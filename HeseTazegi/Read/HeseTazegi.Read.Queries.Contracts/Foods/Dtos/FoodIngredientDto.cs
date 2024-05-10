namespace HeseTazegi.Read.Queries.Contracts.Foods.Dtos
{
    public class FoodIngredientDto
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string FoodAllergen { get; set; }
    }

}
