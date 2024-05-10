using Framework.Domain;
using HeseTazegi.Resources;

namespace HeseTazegi.Domain.Foods.Exceptions
{
    public class NameIsRequiredException : DomainException
    {
        public override string Message => FoodExceptionMessage.NameIsRequiredException;
    }
}
