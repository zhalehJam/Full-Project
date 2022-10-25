using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Tickets
{
    public class SupporterPersonIDIsValidChecker : ISupporterPersonIDIsValidChecker
    {
        private readonly IPersonRepository _personRepository;

        public SupporterPersonIDIsValidChecker(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool IsValid(int personID)
        {
            bool isValid = false;
            if(_personRepository.IsExist(n => n.PersonID == personID))
            {
                isValid = true;
            }
            return isValid;
        }
    }

}
