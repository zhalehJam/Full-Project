﻿using Framework.Core.ApplicationService;
using Framework.Facade;
 
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Facade.Contract;

namespace TicketContext.Facade
{
    public class CenterCommandFacade : FacadeCommandBase, ICenterCommandFacade
    {
        public CenterCommandFacade(IMediatorCommand mediator) : base(mediator)
        {
        }
        
        public async Task AddPart(AddPartCommand addPartCommand)
        {
            var t =  await _mediatorCommand.Send<AddPartCommand,Guid>(addPartCommand);
        }

        public async Task<Guid> CreateCenter(CreateCenterCommand createCenterCommand) 
        { 
            return await _mediatorCommand.Send<CreateCenterCommand,Guid>(createCenterCommand); 
        }

        public async Task DeleteCenter(DeleteCenterCommand deleteCenterCommand)
        {
            var t = await _mediatorCommand.Send<DeleteCenterCommand, Guid>(deleteCenterCommand);

        }

        public async Task DeletePart(DeletePartCommand deletePartCommand)
        {
            var t = await _mediatorCommand.Send<DeletePartCommand, Guid>(deletePartCommand);  
        }

        public async Task EditCenter(EditCenterCommand editCenterCommand)
        {
            //_commandBus.Dispatch(editCenterCommand);
        }
    }
}