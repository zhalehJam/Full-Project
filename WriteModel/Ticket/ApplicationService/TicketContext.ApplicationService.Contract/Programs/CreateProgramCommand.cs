using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Programs
{
    public class CreateProgramCommand : Command
    {

        public string ProgramName { get; set; }
        public string ProgramLink { get; set; }
    }
}
