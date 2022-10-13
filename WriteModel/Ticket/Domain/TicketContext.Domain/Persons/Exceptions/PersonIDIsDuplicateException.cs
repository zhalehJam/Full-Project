using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class PersonIDIsDuplicateException:DomainException
    {
        public override string Message=> PersonResource.PersonIDIsDuplicateException;
    }
}

