using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services
{
    public class CenterIDDupliccationCheck : ICenterIDDuplicationCheck
    {
        ICenterRepository repository;

        public CenterIDDupliccationCheck(ICenterRepository repository)
        {
            this.repository = repository;
        }

        public bool IsDuplicate(int CenerID)
        {
            bool isValid = false;

            if(repository.IsExist(n => n.CenterID == CenerID))
                isValid = true;
            return isValid;
        }

    }

}