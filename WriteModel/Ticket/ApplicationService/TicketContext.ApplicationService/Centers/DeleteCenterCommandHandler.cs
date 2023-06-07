using Framework.Core.ApplicationService;
using MediatR;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class DeleteCenterCommandHandler : IHandler, IRequestHandler<DeleteCenterCommand, Guid>//ICommandHandler<DeleteCenterCommand>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly ICenterIsUsedCheker _centerIsUsedCheker;

        public DeleteCenterCommandHandler(ICenterRepository centerRepository,ICenterIsUsedCheker centerIsUsedCheker)
        {
            _centerRepository = centerRepository;
            _centerIsUsedCheker = centerIsUsedCheker;
        }
        

        public Task<Guid> Handle(DeleteCenterCommand request, CancellationToken cancellationToken)
        {
            Center center = _centerRepository.GetByID(request.Id);
            center.CanDeleteCenter(_centerIsUsedCheker);
            _centerRepository.Delete(center);
            return Task.FromResult(center.Id);

        }
    }
}
