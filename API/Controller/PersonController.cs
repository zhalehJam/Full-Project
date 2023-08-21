using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReadModel.Pagination;
using System.Security.Claims;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons.Queries;
using TicketContext.ReadModel.Query.Contracts.Programs.DataContracts;

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
        public List<PersonDto> GetAllPersons()
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
        public PagedList<PersonDto> GetAllPersonsByPage([FromQuery]PageParameter pageParametr)
        {
            return _personQueryFacade.GetAllPersonsByPage(pageParametr);
        }
        [HttpGet("GetPersonInfoByPersonelCode")]
        public PersonDto GetPersonInfoByPersonelCode(int personnelCode)
        {
            return _personQueryFacade.GetPersonInfoByPersonelCode(personnelCode);
        }

        [HttpGet("GetUserPhoto")]
        public async Task<IActionResult> GetUserPhoto(int personnelCode)
        {

            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://apihrms.shonizcloud.ir");
                    var response =
                        await client.GetAsync($"/HR/api/GetEmployeeInfoWithPhoto?employeeId={personnelCode}");
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    var deserializedData = JObject.Parse(result)["image"].ToString();
                    //return File(Convert.FromBase64String(deserializedData), "image/jpeg");
                    return Ok(deserializedData); 
                }
                catch(HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error : {httpRequestException.Message}");
                }
            }
        }

        [HttpGet("GetPersonInfoByFilters")]
        public async Task<IActionResult> GetPersonInfoByFilters([FromQuery] GetPersonInfoByFiltersQuery pageParametr)
        {
            var persons  =   _personQueryFacade.GetPersonInfoByFilters(pageParametr);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(persons.MetaData));
            return Ok(persons);
        }

    }
}
