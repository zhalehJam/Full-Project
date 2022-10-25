using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Facade.Contract;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
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
        [HttpPut("UpdateProgramLink")]
        public void UpdateProgramLink(UpdateProgramLinkCommand updateProgramLinkCommand)
        {
            _programCommandFacade.UpdateProgramlink(updateProgramLinkCommand);
        }

        [HttpPut("AddPrgramSupporter")]
        public void AddProgramSupporter(AddProgramSupporterCommand addProgramSupporterCommand)
        {
            _programCommandFacade.AddProgramSupporter(addProgramSupporterCommand);
        }
        [HttpDelete("DeleteProgramSupporter")]
        public void DeleteProgramSupporter(DeleteProgramSupporterCommand deleteProgramSupporterCommand)
        {
            _programCommandFacade.DeleteProgramSupporter(deleteProgramSupporterCommand);
        }

    }
}
