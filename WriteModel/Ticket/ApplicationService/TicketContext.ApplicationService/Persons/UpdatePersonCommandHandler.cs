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
        private readonly IPersonIsProgramSupporterChecker _personIsProgramSupporterChecker;

        public UpdatePersonCommandHandler(IPersonRepository personRepository,
                                          IPartIDIsValidChecker partIDIsValidChecker,
                                          IPersonIsProgramSupporterChecker personIsProgramSupporterChecker)
        {
            _personRepository = personRepository;
            _partIDIsValidChecker = partIDIsValidChecker;
            _personIsProgramSupporterChecker = personIsProgramSupporterChecker;
        }
        public void Execute(UpdatePersonCommand command)
        {
            Person person = _personRepository.GetByID(command.Id);
            person.UpdatePersonInfo(command.Name,
                                    command.PartId,
                                    command.PersonRole,
                                    _partIDIsValidChecker,
                                    _personIsProgramSupporterChecker);
            _personRepository.Update(person);
        }
    }
}
