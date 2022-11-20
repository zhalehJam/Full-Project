using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersonIDDuplicateChecker : IPersonIDDuplicateChecker
    {
        private readonly IPersonRepository _personRepository;

        public PersonIDDuplicateChecker(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool IsDuplicate(int personID)
        {
            return _personRepository.IsExist(n => n.PersonID == personID);
        }
    }
}
