using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Tickets
{
    public class PersonIDIsValidChecker : IPersonIDIsValidChecker
    {
        private readonly IPersonRepository _personRepository;

        public PersonIDIsValidChecker(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool IsValid(int personID)
        {
            bool isValid = _personRepository.IsExist(n => n.PersonID == personID);
          return isValid;
        }
    }

}
