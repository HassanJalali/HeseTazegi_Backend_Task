using Framework.Domain;
using HeseTazegi.Resources;

namespace HeseTazegi.Domain.Foods.Exceptions
{
    public class IngredientsAreNotValidException : DomainException
    {
        public override string Message => FoodExceptionMessage.IngredientsAreNotValidException;
    }
}
