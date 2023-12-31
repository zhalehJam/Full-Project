using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Programs
{
    public class DeleteProgramCommand : Command
    {
        public Guid Id { get; set; }
    }
}
