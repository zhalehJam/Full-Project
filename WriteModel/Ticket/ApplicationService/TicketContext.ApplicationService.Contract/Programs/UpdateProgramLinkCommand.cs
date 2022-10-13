using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Program
{
    public class UpdateProgramLinkCommand:Command
    {
        public Guid Id { get; set; }
        public string ProgramLink { get; set; }
    }
}
