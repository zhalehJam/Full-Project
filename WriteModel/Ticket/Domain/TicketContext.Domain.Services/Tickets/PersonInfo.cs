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
        public Guid GetpersonInfo(int personID)
        {
            Guid personPartID = _personRepository.GetByPersonID(n => n.PersonID == personID).PartId;
            return personPartID;
        }
    }
}
