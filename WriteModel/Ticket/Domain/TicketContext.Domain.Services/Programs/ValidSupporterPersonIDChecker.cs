using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.Domain.Services.Programs
{
    public class ValidSupporterPersonIDChecker : IValidSupporterPersonIDChecker
    {
        private readonly IPersonRepository _personRepository;

        public ValidSupporterPersonIDChecker(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool Isvalid(int personID)
        {
            bool valid = false;
            if(_personRepository.IsExist(n => n.PersonID == personID))
                valid = true;
            return valid;
        }
    }
}