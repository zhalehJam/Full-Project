using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services.Centers
{
    public class PartIDUsedChecker : IPartIDUsedChecker
    {
        private readonly IPersonRepository _personRepository;

        public PartIDUsedChecker(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool IsUsed(Guid partGuid)
        {
            bool isUsed = false;
            if(_personRepository.IsExist(n=>n.PartId== partGuid))
                isUsed = true;
            return isUsed;
        }
    }

}