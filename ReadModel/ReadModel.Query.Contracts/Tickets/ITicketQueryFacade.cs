using Framework.Core.Facade;
using ReadModel.Pagination;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Tickets
{
    public interface ITicketQueryFacade:IQueryFacade
    {
        List<TicketDto> GetAllTickets();
        List<TicketDto> GetUserAllTickets(int personID, DateTime fromDate, DateTime toDate);
        TicketDto GetTicketById(Guid Id);
        PagedList<TicketDto> GetAllTicketsByPage(PageParameter pageParametrs);
        PagedList<TicketDto> GetUserTicketsByDateRage(int personID, TicketQueryParameters parameters);
    }
}
