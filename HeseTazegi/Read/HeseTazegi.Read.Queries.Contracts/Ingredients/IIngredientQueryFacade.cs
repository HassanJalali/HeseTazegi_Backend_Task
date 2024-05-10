using Framework.ReadModel;
using HeseTazegi.Read.Queries.Contracts.Ingredients.Dtos;

namespace HeseTazegi.Read.Queries.Contracts.Ingredients
{
    public interface IIngredientQueryFacade: IQueryFacade
    {
        Task<List<IngredientDto>> GetIngredients();
        Task<IngredientDto> GetIngredientById(Guid id);
        Task<IngredientDto> GetIngredientByName(string name);
    }
}
