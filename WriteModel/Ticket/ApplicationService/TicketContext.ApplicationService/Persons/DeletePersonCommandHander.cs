using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.ApplicationService.Persons
{
    public class DeletePersonCommandHander : ICommandHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonIDUsedChecker _personIDUsedChecker;

        public DeletePersonCommandHander(IPersonRepository personRepository,
                                         IPersonIDUsedChecker personIDUsedChecker)
        {
            _personRepository = personRepository;
            _personIDUsedChecker = personIDUsedChecker;
        }
        public void Execute(DeletePersonCommand command)
        {
            Person person = _personRepository.GetByID(command.Id);
            person.CheckPersonCanDelete(_personIDUsedChecker);
            _personRepository.Delete(person);

        }
    }
}
