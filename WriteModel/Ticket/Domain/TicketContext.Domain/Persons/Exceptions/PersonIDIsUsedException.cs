using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class PersonIDIsUsedException:DomainException
    {
        public override string Message => PersonResource.PersonIDIsUsedException;
    }


}

