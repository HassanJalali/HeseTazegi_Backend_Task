using Framework.Domain;
using HeseTazegi.Resources;

namespace HeseTazegi.Domain.Ingredients.Exceptions
{
    public class NameCanNotBeDuplicatedException : DomainException
    {
        public override string Message => IngredientExceptionMessage.NameCanNotBeDuplicatedException;
    }
}
