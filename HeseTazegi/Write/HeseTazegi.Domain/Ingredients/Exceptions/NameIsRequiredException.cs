using Framework.Domain;
using HeseTazegi.Resources;

namespace HeseTazegi.Domain.Ingredients.Exceptions
{
    public class NameIsRequiredException : DomainException
    {
        public override string Message => IngredientExceptionMessage.NameIsRequiredException;
    } 
}
