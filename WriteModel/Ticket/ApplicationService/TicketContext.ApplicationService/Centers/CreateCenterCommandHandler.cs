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
        private readonly ICenterIDValidationCheck CenterIDValidationCheck;
        private readonly ICenterIDDuplicationCheck CenterIDDuplicationCheck;
        private readonly ICenterRepository CenterRepository;
        private readonly IPartIDUsedChecker _partIDUsedChecker;

        public CreateCenterCommandHandler(ICenterIDValidationCheck centerIDValidationCheck,
                                          ICenterIDDuplicationCheck centerIDDuplicationCheck,
                                          ICenterRepository centerRepository,
                                          IPartIDUsedChecker partIDUsedChecker)
        {
            CenterIDValidationCheck = centerIDValidationCheck;
            CenterIDDuplicationCheck = centerIDDuplicationCheck;
            CenterRepository = centerRepository;
            _partIDUsedChecker = partIDUsedChecker;
        }
        //public void Execute(CreateCenterCommand command)
        //{
        //    var center = new Center(CenterIDValidationCheck,
        //                            CenterIDDuplicationCheck,
        //                            _partIDUsedChecker,
        //                            command.CenterName,
        //                            command.CenterID);
        //    CenterRepository.Add(center);
        //}

        public Task<Guid> Handle(CreateCenterCommand request, CancellationToken cancellationToken)
        {
            var center = new Center(CenterIDValidationCheck,
                                    CenterIDDuplicationCheck,
                                    _partIDUsedChecker,
                                    request.CenterName,
                                    request.CenterID);
            CenterRepository.Add(center);
            return Task.FromResult(center.Id);
        }

        //public Task<Guid> Handle(CreateCenterCommand command)
        //{
        //    var center = new Center(CenterIDValidationCheck,
        //                            CenterIDDuplicationCheck,
        //                            _partIDUsedChecker,
        //                            command.CenterName,
        //                            command.CenterID);
        //    CenterRepository.Add(center);
        //    return Task.FromResult(center.Id);
        //}
    }
}
