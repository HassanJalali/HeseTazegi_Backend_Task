using Framework.Core.Persistence;

namespace HeseTazegi.Domain.Foods.Services
{
    public interface IFoodRepository : IRepository
    {
        void CreateFood(Food food);
        bool IsAny(Func<Food, bool> predicated);

    }
}
