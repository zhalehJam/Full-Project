using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class DeletePartCommandHandler : ICommandHandler<DeletePartCommand>
    {
        private readonly ICenterRepository _centerRepository;

        public DeletePartCommandHandler(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }
        public void Execute(DeletePartCommand command)
        {
            Center center = _centerRepository.GetByID(command.CenterId);
            center.DeletePart(command.PartID);
            _centerRepository.Update(center);
        }
    }
}
