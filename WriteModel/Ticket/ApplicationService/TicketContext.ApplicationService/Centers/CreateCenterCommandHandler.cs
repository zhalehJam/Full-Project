using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class CreateCenterCommandHandler : ICommandHandler<CreateCenterCommand>
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
        public void Execute(CreateCenterCommand command)
        {
            var center = new Center(CenterIDValidationCheck,
                                    CenterIDDuplicationCheck,
                                    _partIDUsedChecker,
                                    command.CenterName,
                                    command.CenterID);
            CenterRepository.Add(center);
        }
    }
}
