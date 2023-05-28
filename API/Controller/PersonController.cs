using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Security.Claims;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public void CreatePerson( CreatePersonCommand createPersonCommand)
        {
            _personCommandFacade.CreatePerson(createPersonCommand);
        }

        [HttpPut("UpdatePerson")]
        public void UpdatePerson( UpdatePersonCommand updatePersonCommand)
        {
            _personCommandFacade.UpdatePerson(updatePersonCommand);
        }

        [HttpDelete("DeletePerson")]
        public void DeletePerson(  DeletePersonCommand deletePersonCommand)
        {
            _personCommandFacade.DeletePerson(deletePersonCommand);
        }

        [HttpGet("GetAllPersons")]
        public IList<PersonDto> GetAllPersons()
        {

            var identity = User.Identity as ClaimsIdentity;
            return _personQueryFacade.GetAllPersons();
        }

        [HttpGet("GetPersonById")]
        public PersonDto GetPersonById( Guid Id)
        {
            return _personQueryFacade.GetPersonById(Id);
        }

        [HttpGet("GetAllPersonsByPage")]
        public PagedList<PersonDto> GetAllPersonsByPage([FromQuery]PageParametr pageParametr)
        {
            return _personQueryFacade.GetAllPersonsByPage(pageParametr);
        }
        [HttpGet("GetPersonInfoByPersonelCode")]
        public PersonDto GetPersonInfoByPersonelCode(int personnelCode)
        {
            return _personQueryFacade.GetPersonInfoByPersonelCode(personnelCode);
        }
    }
}
