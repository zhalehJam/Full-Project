using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class InvalidRoleTypeException : DomainException
    {
        public override string Message => PersonResource.InvalidRoleTypeException; 
    }
}

