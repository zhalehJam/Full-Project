
using System.Linq;
using System.Security.AccessControl;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PartIdIsValidChecker : IPartIDIsValidChecker
    {
        public readonly ICenterRepository CenterRepository;
        public PartIdIsValidChecker(ICenterRepository centerRepository)
        {
            CenterRepository = centerRepository;
        }
        public bool IsValid(Guid partId)
        {
            return CenterRepository.IsExist(c => c.Parts.Any(s => s.Id == partId));
        }
    }
}
