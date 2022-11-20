using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Tickets
{
    public class DeleteTicketCommand:Command
    { 
        public Guid Id { get; set; }
        public int SupporterUser { get; set; }
    }
}
