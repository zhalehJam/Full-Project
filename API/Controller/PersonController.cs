using Microsoft.AspNetCore.Mvc;
using ReadModel.Query.Contracts.Centers;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.Centers.DataContracts;

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
        public void CreatePerson(CreatePersonCommand createPersonCommand)
        {
            _personCommandFacade.CreatePerson(createPersonCommand);
        }

        [HttpPut("UpdatePerson")]
        public void UpdatePerson(UpdatePersonCommand updatePersonCommand)
        {
            _personCommandFacade.UpdatePerson(updatePersonCommand);
        }

        [HttpDelete("DeletePerson")]
        public void DeletePerson(DeletePersonCommand deletePersonCommand)
        {
            _personCommandFacade.DeletePerson(deletePersonCommand);
        }

        [HttpGet("GetAllPersons")]
        public IList<PersonDto> GetAllPersons()
        {
           return _personQueryFacade.GetAllPersons();
        }

        [HttpGet("GetPersonById")]
        public PersonDto GetPersonById(Guid Id)
        {
            return _personQueryFacade.GetPersonById(Id);
        }
    }
}
