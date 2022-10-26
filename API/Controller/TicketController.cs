using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Facade.Contract;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController:ControllerBase
    {
        private readonly ITicketCommandFacade _ticketCommandFacade;

        public TicketController(ITicketCommandFacade ticketCommandFacade)
        {
            _ticketCommandFacade = ticketCommandFacade;
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
    }
}
