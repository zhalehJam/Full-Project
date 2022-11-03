using Framework.Core.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Tickets
{
    public interface ITicketQueryFacade:IQueryFacade
    {
        List<TicketDto> GetAllTickets();
        TicketDto GetTicketById(Guid Id);
    }
}
