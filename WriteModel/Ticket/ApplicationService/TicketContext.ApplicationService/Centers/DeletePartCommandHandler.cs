﻿using Framework.Core.ApplicationService;
using MediatR;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.ApplicationService.Centers
{
    public class DeletePartCommandHandler : IHandler,  IRequestHandler<DeletePartCommand, Guid>//ICommandHandler<DeletePartCommand>
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

        public Task<Guid> Handle(DeletePartCommand request, CancellationToken cancellationToken)
        {
            Center center = _centerRepository.GetByID(request.CenterId);
            center.DeletePart(_partIDUsedChecker, request.PartID);
            _centerRepository.Update(center);
            return Task.FromResult(center.Id);

        }
    }
}
