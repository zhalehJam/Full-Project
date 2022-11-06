using Microsoft.AspNetCore.Mvc;
using PagedList;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        private readonly IPersonCommandFacade _personCommandFacade;
        private readonly IPersonQueryFacade _personQueryFacade;

        public PersonController(IPersonCommandFacade personCommandFacade,IPersonQueryFacade personQueryFacade)
        {
            _personCommandFacade = personCommandFacade;
            _personQueryFacade = personQueryFacade;
        }
        
        [HttpPost("CreatePerson")]
        public void CreatePerson([FromQuery] CreatePersonCommand createPersonCommand)
        {
            _personCommandFacade.CreatePerson(createPersonCommand);
        }

        [HttpPut("UpdatePerson")]
        public void UpdatePerson([FromQuery] UpdatePersonCommand updatePersonCommand)
        {
            _personCommandFacade.UpdatePerson(updatePersonCommand);
        }

        [HttpDelete("DeletePerson")]
        public void DeletePerson([FromQuery] DeletePersonCommand deletePersonCommand)
        {
            _personCommandFacade.DeletePerson(deletePersonCommand);
        }

        [HttpGet("GetAllPersons")]
        public IList<PersonDto> GetAllPersons()
        {
           return _personQueryFacade.GetAllPersons();
        }

        [HttpGet("GetPersonById")]
        public PersonDto GetPersonById([FromQuery] Guid Id)
        {
            return _personQueryFacade.GetPersonById(Id);
        }

        [HttpGet("GetAllPersonsByPage")]
        public PagedList<PersonDto> GetAllPersonsByPage([FromQuery]PageParametr pageParametr)
        {
            return _personQueryFacade.GetAllPersonsByPage(pageParametr);
        }
    }
}
