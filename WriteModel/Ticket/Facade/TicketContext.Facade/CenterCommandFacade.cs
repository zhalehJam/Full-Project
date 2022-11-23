using Framework.Core.ApplicationService;
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

        //public CenterCommandFacade(ICommandBus commandBus) : base(commandBus)
        //{
        //}

        public async void AddPart(AddPartCommand addPartCommand)
        {
            //_commandBus.Dispatch(addPartCommand);
           // var e = await _mediator.Send(addPartCommand);
        }

        public async Task<Guid> CreateCenter(CreateCenterCommand createCenterCommand) 
        { 
            return await _mediatorCommand.Send<CreateCenterCommand,Guid>(createCenterCommand); 
        }

        public void DeleteCenter(DeleteCenterCommand deleteCenterCommand)
        {
            //_commandBus.Dispatch(deleteCenterCommand);
        }

        public void DeletePart(DeletePartCommand deletePartCommand)
        {
            //_commandBus.Dispatch(deletePartCommand);

        }

        public void EditCenter(EditCenterCommand editCenterCommand)
        {
            //_commandBus.Dispatch(editCenterCommand);
        }
    }
}