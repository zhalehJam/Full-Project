using Framework.Core.Domain;

namespace TicketContext.Domain.Programs.DomainServices
{
    public interface IValidSupporterPersonIDChecker:IDomainService
    {
        bool Isvalid(Int32 personID);
    }
}
