using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Programs
{
    public class UpdateProgramLinkCommand:Command
    {
        public Guid Id { get; set; }
        public string ProgramLink { get; set; }
    }
}
