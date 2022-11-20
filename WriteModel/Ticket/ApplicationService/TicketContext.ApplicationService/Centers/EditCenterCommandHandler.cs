using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class EditCenterCommandHandler : ICommandHandler<EditCenterCommand>
    {
        private readonly ICenterRepository _centerRepository;

        public EditCenterCommandHandler(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }
        public void Execute(EditCenterCommand command)
        {
            Center center = _centerRepository.GetByID(command.Id);
            center.UpdateCenterName(command.Name);
        }
    }
}
