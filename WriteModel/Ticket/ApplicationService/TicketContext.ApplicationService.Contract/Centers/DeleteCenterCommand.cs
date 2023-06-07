using Framework.Core.ApplicationService;
using MediatR;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class DeleteCenterCommand:Command, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
