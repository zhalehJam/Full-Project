using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReadModel.Pagination;
using System.Security.Claims;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Tickets;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

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
        public void CreateTicket(CreateTicketCommand createTicketCommand)
        {
            _ticketCommandFacade.CreateTicket(createTicketCommand);
        }

        [HttpPut]
        public void UpdateTicket(UpdateTicketCommand updateTicketCommand)
        {
            _ticketCommandFacade.UpdateTicket(updateTicketCommand);
        }
        [HttpDelete]
        public void DeleteTicket(DeleteTicketCommand deleteTicketCommand)
        {
            _ticketCommandFacade.DeleteTicket(deleteTicketCommand);
        }

        [HttpGet("GetAllTickets")]
        public List<TicketDto> GetAllTickets()
        {
            return _ticketQueryFacade.GetAllTickets();
        }
        [HttpGet("GetAllTicketsByPage")]
        public PagedList<TicketDto> GetAllTicketsByPage([FromQuery] PageParametr parameters)
        {

            var identity = User.Identity as ClaimsIdentity;
            return _ticketQueryFacade.GetAllTicketsByPage(pageParametrs: parameters);
        }
        [HttpGet("GetTicketById")]
        public TicketDto GetTicketById([FromQuery] Guid Id)
        {
            return _ticketQueryFacade.GetTicketById(Id);
        }

        [HttpGet("GetUserTicketsByDateRage")]
        public IActionResult GetUserTicketsByDateRage([FromQuery] TicketQueryParameters parameters)
        {
            var identity = User.Identity as ClaimsIdentity;
            var tickets = _ticketQueryFacade.GetUserTicketsByDateRage(Convert.ToInt32(identity.Name), parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(tickets.MetaData));
            return Ok(tickets);

        }
    }
}
