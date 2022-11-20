using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class DeleteCenterCommandHandler : ICommandHandler<DeleteCenterCommand>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly ICenterIsUsedCheker _centerIsUsedCheker;

        public DeleteCenterCommandHandler(ICenterRepository centerRepository,ICenterIsUsedCheker centerIsUsedCheker)
        {
            _centerRepository = centerRepository;
            _centerIsUsedCheker = centerIsUsedCheker;
        }
        public void Execute(DeleteCenterCommand command)
        {
            Center center = _centerRepository.GetByID(command.Id);
            center.CanDeleteCenter(_centerIsUsedCheker);
            _centerRepository.Delete(center);
        }
    }
}
