using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class DeletePartCommand:Command
    {
        public Guid CenterId { get; set; }
        public int PartID { get; set; }
    }
}
