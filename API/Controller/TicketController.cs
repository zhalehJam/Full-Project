using Microsoft.AspNetCore.Mvc;
using PagedList;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Tickets;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketCommandFacade _ticketCommandFacade;
        private readonly ITicketQueryFacade _ticketQueryFacade;

        public TicketController(ITicketCommandFacade ticketCommandFacade, ITicketQueryFacade ticketQueryFacade)
        {
            _ticketCommandFacade = ticketCommandFacade;
            _ticketQueryFacade = ticketQueryFacade;
        }
        [HttpPost]
        public void CreateTicket([FromQuery] CreateTicketCommand createTicketCommand)
        {
            _ticketCommandFacade.CreateTicket(createTicketCommand);
        }

        [HttpPut]
        public void UpdateTicket([FromQuery] UpdateTicketCommand updateTicketCommand)
        {
            _ticketCommandFacade.UpdateTicket(updateTicketCommand);
        }

        [HttpGet("GetAllTickets")]
        public List<TicketDto> GetAllTickets()
        {
            return _ticketQueryFacade.GetAllTickets();
        }
        [HttpGet("GetAllTicketsByPage")]
        public PagedList<TicketDto> GetAllTicketsByPage([FromQuery] PageParametr parameters)
        {
            return _ticketQueryFacade.GetAllTicketsByPage(pageParametrs: parameters);
        }
        [HttpGet("GetTicketById")]
        public TicketDto GetTicketById([FromQuery] Guid Id)
        {
            return _ticketQueryFacade.GetTicketById(Id);
        }
    }
}
