using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services
{
    public class CenterIDDupliccationCheck : ICenterIDDuplicationCheck
    {
        ICenterRepository _repository;

        public CenterIDDupliccationCheck(ICenterRepository repository)
        {
            _repository = repository;
        }

        public bool IsDuplicate(int CenerID)
        {
            bool isValid = false;

            if(_repository.IsExist(n => n.CenterID == CenerID))
                isValid = true;
            return isValid;
        }

    }
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
            if(_personRepository.IsExist(n=>n.Id== partGuid))
                isUsed = true;
            return isUsed;
        }
    }

}