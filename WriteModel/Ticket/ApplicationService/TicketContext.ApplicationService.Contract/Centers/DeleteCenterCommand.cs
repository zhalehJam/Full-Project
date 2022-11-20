using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class DeleteCenterCommand:Command
    {
        public Guid Id { get; set; }
    }
}
