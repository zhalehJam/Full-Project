using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Facade.Contract;

namespace API.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterCommandFacade _centerCommandFacade;

        public CenterController(ICenterCommandFacade centerCommandFacade)
        {
            _centerCommandFacade = centerCommandFacade;
        }
        [HttpPost("CreateCenter")]
        public void CreateCenter(CreateCenterCommand createCenterCommand)
        {
            _centerCommandFacade.CeateCenter(createCenterCommand);
        }
        [HttpPost("AddPart")]
        public void AddPart(AddPartCommand addPartCommand)
        {
            _centerCommandFacade.AddPart(addPartCommand);
        }

        [HttpPost("DeletePart")]
        public void DeletePart(DeletePartCommand deletePartCommand)
        {
            _centerCommandFacade.DeletePart(deletePartCommand);
        }
    }
}
