using HeseTazegi.Read.Context.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeseTazegi.WebApi.Utilities
{
    public class DataSeeder
    {
        private readonly HeseTazegiReadContext _context;

        public DataSeeder(HeseTazegiReadContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            await SeedIngredientsAsync();
        }

        private async Task SeedIngredientsAsync()
        {
            if (!_context.Ingredients.Any())
            {
                var streamReader = new StreamReader("./files/ingredients.json");
                var json = await streamReader.ReadToEndAsync();
                var ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(json);
                await _context.Ingredients.AddRangeAsync(ingredients);
                await _context.SaveChangesAsync();
            }
        }
    }
}
