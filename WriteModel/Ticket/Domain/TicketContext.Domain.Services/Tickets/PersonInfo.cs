using TicketContext.Domain.Persons;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Tickets
{
    public class PersonInfo : IPersonInfo
    {
        private readonly IPersonRepository _personRepository;

        public PersonInfo(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Guid GetPersonInfo(int personID)
        {
            return _personRepository.GetByPersonID(n => n.PersonID == personID).PartId;
        }
    }
}
