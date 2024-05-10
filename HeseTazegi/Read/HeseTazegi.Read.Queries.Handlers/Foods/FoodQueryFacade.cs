using HeseTazegi.Read.Context.Models;
using HeseTazegi.Read.Queries.Contracts.Foods;
using HeseTazegi.Read.Queries.Contracts.Foods.Dtos;
using Microsoft.EntityFrameworkCore;
using FoodIngredient = HeseTazegi.Read.Context.Models.FoodIngredient;

namespace HeseTazegi.Read.Queries.Handlers.Foods
{
    public class FoodQueryFacade : IFoodQueryFacade
    {
        private readonly HeseTazegiReadContext _context;

        public FoodQueryFacade(HeseTazegiReadContext context)
        {
            _context = context;
        }


        public async Task<List<FoodDto>> GetFoods()
        {
            var foods = await _context.Foods.Include(f => f.FoodIngredients)
                                            .AsSplitQuery()
                                            .ToListAsync();

            var foodsDto = new List<FoodDto>();
            foreach (var food in foods)
            {
                var foodDto = new FoodDto
                {
                    Id = food.Id,
                    Name = food.Name,
                    FoodIngredients = await GetIngredients(food.FoodIngredients)
                };

                foodsDto.Add(foodDto);
            }

            return foodsDto;
        }

        private async Task<List<FoodIngredientDto>> GetIngredients(ICollection<FoodIngredient> foodIngredients)
        {
            var foodIngredientsDto = new List<FoodIngredientDto>();
            foreach (var foodIngredient in foodIngredients)
            {
                var ingredient = await _context.Ingredients
                                               .FirstOrDefaultAsync(i => i.Id == foodIngredient.IngredientId);

                var foodIngredientDto = new FoodIngredientDto
                {
                    IngredientId = ingredient.Id,
                    IngredientName = ingredient.Name,
                    FoodAllergen = MapFoodAllergenToPersianDescription(ingredient.IsFoodAllergen)
                };

                foodIngredientsDto.Add(foodIngredientDto);
            }

            return foodIngredientsDto;
        }

        private string MapFoodAllergenToPersianDescription(bool isFoodAllergen)
        {
            if (isFoodAllergen)
                return "حساسیت زا";

            else
                return "غیر حساسیت زا";
        }
    }
}
