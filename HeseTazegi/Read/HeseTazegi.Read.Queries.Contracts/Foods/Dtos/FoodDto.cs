namespace HeseTazegi.Read.Queries.Contracts.Foods.Dtos
{
    public class FoodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<FoodIngredientDto> FoodIngredients { get; set; }
    }

}
