using Framework.ReadModel;
using HeseTazegi.Read.Queries.Contracts.Foods.Dtos;

namespace HeseTazegi.Read.Queries.Contracts.Foods
{
    public interface IFoodQueryFacade : IQueryFacade
    {
        Task<List<FoodDto>> GetFoods();
    }

}
