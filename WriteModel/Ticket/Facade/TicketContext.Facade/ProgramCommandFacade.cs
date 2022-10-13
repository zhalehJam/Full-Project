using Framework.Core.ApplicationService;
using Framework.Facade;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Facade.Contract;

namespace TicketContext.Facade
{
    public class ProgramCommandFacade : FacadeCommandBase, IProgramCommandFacade
    {
        public ProgramCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void CreateProgram(CreateProgramCommand createProgramCommand)
        {
            _commandBus.Dispatch(createProgramCommand);
        }

        public void UpdateProgramlink(UpdateProgramLinkCommand updateProgramLinkCommand)
        {
            _commandBus.Dispatch(updateProgramLinkCommand);
        }
    }
}
