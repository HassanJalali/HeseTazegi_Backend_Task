using Framework.Domain;
using HeseTazegi.Resources;

namespace HeseTazegi.Domain.Foods.Exceptions
{
    public class IngredientIsReuqiredException : DomainException
    {
        public override string Message => FoodExceptionMessage.IngredientIsReuqiredException;
    }
}
