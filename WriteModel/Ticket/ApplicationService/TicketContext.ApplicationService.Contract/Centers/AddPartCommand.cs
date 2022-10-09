using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class AddPartCommand :Command
    {
        public Guid CenterId { get; set; }
        public string? PartName { get; set; }
        public int PartID { get; set; }
    }
}
