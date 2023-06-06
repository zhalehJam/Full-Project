using Framework.Core.ApplicationService;
using MediatR;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class AddPartCommand :Command ,IRequest<Guid>
    {
        public Guid CenterId { get; set; }
        public string? PartName { get; set; }
        public int PartID { get; set; }
    }
}
