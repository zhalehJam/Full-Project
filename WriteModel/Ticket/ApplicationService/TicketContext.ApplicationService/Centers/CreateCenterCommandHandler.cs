using Framework.Core.ApplicationService;
using MediatR;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class CreateCenterCommandHandler : IHandler, IRequestHandler<CreateCenterCommand, Guid>
    //MediatorCommandHandler<CreateCenterCommand,Guid>,
    //,ICommandHandler<CreateCenterCommand>
    {
        private readonly ICenterIDValidationCheck _centerIdValidationCheck;
        private readonly ICenterIDDuplicationCheck _centerIdDuplicationCheck;
        private readonly ICenterRepository _centerRepository;
        private readonly IPartIDUsedChecker _partIdUsedChecker;

        public CreateCenterCommandHandler(ICenterIDValidationCheck centerIDValidationCheck,
                                          ICenterIDDuplicationCheck centerIDDuplicationCheck,
                                          ICenterRepository centerRepository,
                                          IPartIDUsedChecker partIDUsedChecker)
        {
            _centerIdValidationCheck = centerIDValidationCheck;
            _centerIdDuplicationCheck = centerIDDuplicationCheck;
            _centerRepository = centerRepository;
            _partIdUsedChecker = partIDUsedChecker;
        } 
        public Task<Guid> Handle(CreateCenterCommand request, CancellationToken cancellationToken)
        {
            var center = new Center(_centerIdValidationCheck,
                                    _centerIdDuplicationCheck,
                                    _partIdUsedChecker,
                                    request.CenterName,
                                    request.CenterID);
            _centerRepository.Add(center);
            return Task.FromResult(center.Id);
        } 
    }
}
