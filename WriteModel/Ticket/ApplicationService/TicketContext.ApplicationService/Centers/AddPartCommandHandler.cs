using Framework.Core.ApplicationService;
using MediatR;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class AddPartCommandHandler : IHandler ,IRequestHandler<AddPartCommand, Guid>//ICommandHandler<AddPartCommand>
    {
        private readonly ICenterRepository _centerRepository;
        private IPartIDValidaionCheker _partIDValidaionCheker;

        public AddPartCommandHandler(ICenterRepository centerRepository,
                                     IPartIDValidaionCheker partIDValidaionCheker)
        {
            _centerRepository = centerRepository;
            _partIDValidaionCheker = partIDValidaionCheker;
        }
        //public void Execute(AddPartCommand command)
        //{
        //    Center center = _centerRepository.GetByID(command.CenterId);
        //    Part part = new Part(command.PartName, command.PartID, _partIDValidaionCheker);
        //    center.AddPart(part);
        //    _centerRepository.Update(center);
        //}
 

        Task<Guid> IRequestHandler<AddPartCommand, Guid>.Handle(AddPartCommand request, CancellationToken cancellationToken)
        {
            Center center = _centerRepository.GetByID(request.CenterId);
            Part part = new Part(request.PartName, request.PartID, _partIDValidaionCheker);
            center.AddPart(part);
            _centerRepository.Update(center);
            return Task.FromResult(part.Id);
        }
    }
}
