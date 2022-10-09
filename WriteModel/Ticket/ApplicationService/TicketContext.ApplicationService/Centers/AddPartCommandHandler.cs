using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class AddPartCommandHandler : ICommandHandler<AddPartCommand>
    {
        private readonly ICenterRepository _centerRepository;
        private IPartIDValidaionCheker _partIDValidaionCheker;

        public AddPartCommandHandler(ICenterRepository centerRepository,
                                     IPartIDValidaionCheker partIDValidaionCheker)
        {
            _centerRepository = centerRepository;
            _partIDValidaionCheker = partIDValidaionCheker;
        }
        public void Execute(AddPartCommand command)
        {
            Center center = _centerRepository.GetByID(command.CenterId);
            Part part = new Part(command.PartName, command.PartID, _partIDValidaionCheker);
            center.AddPart(part);
            _centerRepository.Update(center);
        }
    }
}
