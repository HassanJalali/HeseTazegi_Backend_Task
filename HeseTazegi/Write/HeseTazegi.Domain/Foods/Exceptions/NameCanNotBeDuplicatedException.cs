using Framework.Domain;
using HeseTazegi.Resources;

namespace HeseTazegi.Domain.Foods.Exceptions
{
    public class NameCanNotBeDuplicatedException : DomainException
    {
        public override string Message => FoodExceptionMessage.NameCanNotBeDuplicatedException;
    }
}
