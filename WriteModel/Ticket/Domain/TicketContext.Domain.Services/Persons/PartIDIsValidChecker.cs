
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
        public bool Isvalid(  Guid partId)
        {
            return _centerRepository.IsExist(c => c.Parts.Any(s => s.Id == partId));
        }
    }
}
