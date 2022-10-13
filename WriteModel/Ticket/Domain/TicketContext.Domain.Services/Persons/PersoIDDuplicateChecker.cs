using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersoIDDuplicateChecker : IPersoIDDuplicateChecker
    {
        private readonly IPersonRepository _personRepository;

        public PersoIDDuplicateChecker(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool IsDuplicate(int personID)
        {
            bool isduplicate = false;
            if(_personRepository.IsExist(n => n.PersonID == personID))
                isduplicate = true;
            return isduplicate;
        }
    }
}
