using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class DeletePartCommandHandler : ICommandHandler<DeletePartCommand>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IPartIDUsedChecker _partIDUsedChecker;

        public DeletePartCommandHandler(ICenterRepository centerRepository,
                                        IPartIDUsedChecker partIDUsedChecker)
        {
            _centerRepository = centerRepository;
            _partIDUsedChecker = partIDUsedChecker;
        }
        public void Execute(DeletePartCommand command)
        {
            Center center = _centerRepository.GetByID(command.CenterId);
            center.DeletePart(_partIDUsedChecker,command.PartID);
            _centerRepository.Update(center);
        }
    }
}
