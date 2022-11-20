using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Program
{
    public class DeleteProgramCommand : Command
    {
        public Guid Id { get; set; }
    }
}
