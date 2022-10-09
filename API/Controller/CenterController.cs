using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Facade.Contract;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterCommandFacade CenterCommandFacade;

        public CenterController(ICenterCommandFacade centerCommandFacade)
        {
            CenterCommandFacade = centerCommandFacade;
        }
        [HttpPost("CreateCenter")]
        public void CreateCenter(CreateCenterCommand createCenterCommand)
        {
            CenterCommandFacade.CeateCenter(createCenterCommand);
        }
        [HttpPost("AddPart")]
        public void AddPar(AddPartCommand addPartCommand)
        {
            CenterCommandFacade.AddPart(addPartCommand);
        }
    }
}
