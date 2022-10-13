using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Facade.Contract;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController:ControllerBase
    {
        private readonly IProgramCommandFacade _programCommandFacade;

        public ProgramController(IProgramCommandFacade programCommandFacade)
        {
            _programCommandFacade = programCommandFacade;
        }
        [HttpPost("CreateProgram")]
        public void CreatePrgram(CreateProgramCommand createProgramCommand)
        {
            _programCommandFacade.CreateProgram(createProgramCommand);
        }
        [HttpPost("UpdateProgramLink")]
        public void UpdateProgramLink(UpdateProgramLinkCommand updateProgramLinkCommand)
        {
            _programCommandFacade.UpdateProgramlink(updateProgramLinkCommand);
        }

    }
}
