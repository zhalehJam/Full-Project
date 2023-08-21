using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.Programs;
using TicketContext.ReadModel.Query.Contracts.Programs.DataContracts;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProgramController : ControllerBase
    {
        private readonly IProgramCommandFacade _programCommandFacade;
        private readonly IProgramQueryFacade _programQueryFacade;

        public ProgramController(IProgramCommandFacade programCommandFacade, IProgramQueryFacade programQueryFacade)
        {
            _programCommandFacade = programCommandFacade;
            _programQueryFacade = programQueryFacade;
        }
        [HttpPost]
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
        [HttpPut("DeleteProgramSupporter")]
        public void DeleteProgramSupporter(DeleteProgramSupporterCommand deleteProgramSupporterCommand)
        {
            _programCommandFacade.DeleteProgramSupporter(deleteProgramSupporterCommand);
        }
        [HttpDelete]
        public void DeleteProgram(DeleteProgramCommand deleteProgramCommand)
        {
            _programCommandFacade.DeleteProgram(deleteProgramCommand);
        }

        [HttpGet("GetAllPrograms")]
        public IList<ProgramDto> GetAllPrograms()
        {
            return _programQueryFacade.GetAllPrograms();
        }

        [HttpGet("GetProgramById")]
        public ProgramDto GetProgramById([FromQuery] Guid Id)
        {
            return _programQueryFacade.GetProgramById(Id);
        }
        [HttpGet("GetSupporterProgramsList")]
        public List<ProgramDto> GetSupporterProgramsList(int supporterCode) {
            return _programQueryFacade.GetSupporterProgramsList(supporterCode);
        }
    }
}