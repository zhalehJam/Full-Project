using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.Programs;
using TicketContext.ReadModel.Query.Contracts.Programs.DataContracts;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramCommandFacade _programCommandFacade;
        private readonly IProgramQueryFacade _programQueryFacade;

        public ProgramController(IProgramCommandFacade programCommandFacade, IProgramQueryFacade programQueryFacade)
        {
            _programCommandFacade = programCommandFacade;
            _programQueryFacade = programQueryFacade;
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

        [HttpGet("GetAllPrograms")]
        public IList<ProgramDto> GetAllPrograms()
        {
            return _programQueryFacade.GetAllPrograms();
        }

        [HttpGet("GetProgramById")]
        public ProgramDto GetProgramById(Guid Id)
        {
            return _programQueryFacade.GetProgramById(Id);
        }
    }
}
