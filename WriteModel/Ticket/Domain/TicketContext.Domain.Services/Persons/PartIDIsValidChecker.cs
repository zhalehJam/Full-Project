
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PartIDIsValidChecker : IPartIDIsValidChecker
    {
        ICenterRepository _centerRepository;
        public PartIDIsValidChecker(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }
        public bool Isvalid(Guid centerId, Guid partId)
        {
            bool isValid = false;
            var center = _centerRepository.GetByID(centerId);
            if(center != null)
            {
                if(center.Parts.Where(n => n.Id == partId).Count() != 0)
                    isValid = true;
            }
            return isValid;
        }
    }
}
