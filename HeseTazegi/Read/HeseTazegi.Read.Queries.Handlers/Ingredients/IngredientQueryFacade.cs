using HeseTazegi.Read.Context.Models;
using HeseTazegi.Read.Queries.Contracts.Ingredients;
using HeseTazegi.Read.Queries.Contracts.Ingredients.Dtos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace HeseTazegi.Read.Queries.Handlers.Ingredients
{
    // 1- Insted of having 3 api for getting ingredient we can also have one and return value base on arg.

    public class IngredientQueryFacade : IIngredientQueryFacade
    {
        private readonly HeseTazegiReadContext _context;

        public IngredientQueryFacade(HeseTazegiReadContext context)
        {
            _context = context;
        }


        public async Task<List<IngredientDto>> GetIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();

            var ingredientDto = new List<IngredientDto>();
            ingredients.ForEach(item =>
            {
                var ingredient = MapToIngredientDto(item);
                ingredientDto.Add(ingredient);
            });

            return ingredientDto;
        }

        public async Task<IngredientDto> GetIngredientById(Guid id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            return MapToIngredientDto(ingredient);
        }

        public async Task<IngredientDto> GetIngredientByName(string name)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Name == name);
            return MapToIngredientDto(ingredient);
        }

        private IngredientDto MapToIngredientDto(Ingredient ingredient)
        {
            var ingredientDto = new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                FoodAllergen = MapFoodAllergenToPersianDescription(ingredient.IsFoodAllergen)
            };

            return ingredientDto;
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

