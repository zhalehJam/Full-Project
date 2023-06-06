using Framework.Core.ApplicationService;
using MediatR;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class DeletePartCommand:Command, IRequest<Guid>
    {
        public Guid CenterId { get; set; }
        public int PartID { get; set; }
    }
}
