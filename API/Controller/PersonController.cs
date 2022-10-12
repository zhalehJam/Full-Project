using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        private readonly IPersonCommandFacade _personCommandFacade;

        public PersonController(IPersonCommandFacade personCommandFacade)
        {
            _personCommandFacade = personCommandFacade;
        }
        
        [HttpPost("CreatePerson")]
        public void CreatePerson(CreatePersonCommand createPersonCommand)
        {
            _personCommandFacade.CreatePerson(createPersonCommand);
        }

        [HttpPost("UpdatePerson")]
        public void UpdatePerson(UpdatePersonCommand updatePersonCommand)
        {
            _personCommandFacade.UpdatePerson(updatePersonCommand);
        }
    }
}
