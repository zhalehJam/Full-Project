using Framework.Core.Facade;
using ReadModel.Pagination;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Tickets
{
    public interface ITicketQueryFacade:IQueryFacade
    {
        List<TicketDto> GetAllTickets();
        TicketDto GetTicketById(Guid Id);
        PagedList<TicketDto> GetAllTicketsByPage(PageParametr pageParametrs);
        PagedList<TicketDto> GetUserTicketsByDateRage(int personID, TicketQueryParameters parameters);
    }
}
