using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.ApplicationService.Persons
{
    public class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPartIDIsValidChecker _partIDIsValidChecker;

        public UpdatePersonCommandHandler(IPersonRepository personRepository,
                                          IPartIDIsValidChecker partIDIsValidChecker)
        {
            _personRepository = personRepository;
            _partIDIsValidChecker = partIDIsValidChecker;
        }
        public void Execute(UpdatePersonCommand command)
        {
            Person person = _personRepository.GetByID(command.Id);
            person.UpdatePersonInfo(command.Name, 
                                    command.PartId, _partIDIsValidChecker);
            _personRepository.Update(person);
        }
    }
}
