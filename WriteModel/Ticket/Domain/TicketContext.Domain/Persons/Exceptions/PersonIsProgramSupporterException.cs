using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class PersonIsProgramSupporterException:DomainException { 
        public override string Message => PersonResource.PersonIsProgramSupporterException;

    }
}

