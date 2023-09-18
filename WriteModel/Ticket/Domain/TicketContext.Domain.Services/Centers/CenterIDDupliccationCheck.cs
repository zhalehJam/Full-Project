using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services.Centers
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

}