using Framework.Core.ApplicationService;
using Framework.Facade;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Facade.Contract;

namespace TicketContext.Facade
{
    public class CenterCommandFacade : FacadeCommandBase, ICenterCommandFacade
    {
        public CenterCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void AddPart(AddPartCommand addPartCommand)
        {
            _commandBus.Dispatch(addPartCommand);
        }

        public void CeateCenter(CreateCenterCommand createCenterCommand)
        {
            _commandBus.Dispatch(createCenterCommand);
        }

        public void DeleteCenter(DeleteCenterCommand deleteCenterCommand)
        {
            _commandBus.Dispatch(deleteCenterCommand);
        }

        public void DeletePart(DeletePartCommand deletePartCommand)
        {
            _commandBus.Dispatch(deletePartCommand);

        }

        public void EditCenter(EditCenterCommand editCenterCommand)
        {
            _commandBus.Dispatch(editCenterCommand);
        }
    }
}