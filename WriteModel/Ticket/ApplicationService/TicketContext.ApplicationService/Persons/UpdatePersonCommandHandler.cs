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
        private readonly IPersonIsProgramSuppoerterChecker _personIsProgramSuppoerterChecker;

        public UpdatePersonCommandHandler(IPersonRepository personRepository,
                                          IPartIDIsValidChecker partIDIsValidChecker,
                                          IPersonIsProgramSuppoerterChecker personIsProgramSuppoerterChecker)
        {
            _personRepository = personRepository;
            _partIDIsValidChecker = partIDIsValidChecker;
            _personIsProgramSuppoerterChecker = personIsProgramSuppoerterChecker;
        }
        public void Execute(UpdatePersonCommand command)
        {
            Person person = _personRepository.GetByID(command.Id);
            person.UpdatePersonInfo(command.Name,
                                    command.PartId,
                                    command.PersonRole,
                                    _partIDIsValidChecker,
                                    _personIsProgramSuppoerterChecker);
            _personRepository.Update(person);
        }
    }
}
