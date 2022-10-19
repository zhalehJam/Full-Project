using Framework.Core.ApplicationService;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;

namespace TicketContext.Facade
{
    public class PersonCommandFacade : FacadeCommandBase, IPersonCommandFacade
    {
        public PersonCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void CreatePerson(CreatePersonCommand createPersonCommand)
        {
            _commandBus.Dispatch(createPersonCommand);
        }

        public void DeletePerson(DeletePersonCommand deletePersonCommand)
        {
            _commandBus.Dispatch(deletePersonCommand);
        }

        public void UpdatePerson(UpdatePersonCommand updatePersonCommand)
        {
            _commandBus.Dispatch(updatePersonCommand);
        }

    }
}
