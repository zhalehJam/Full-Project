using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.ApplicationService.Persons
{
    public class CreatePerosnCommandHandler : ICommandHandler<CreatePersonCommand>
    {
        private readonly IPersonIDValidationChecker _personIDValidationChecker;
        private readonly IPartIDIsValidChecker _partIDIsValidChecker;
        private readonly IPersonIDDuplicateChecker _persoIDDuplicateChecker;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonIDUsedChecker _personIDUsedChecker;

        public CreatePerosnCommandHandler(IPersonIDValidationChecker personIDValidationChecker,
                                          IPartIDIsValidChecker partIDIsValidChecker,
                                          IPersonIDDuplicateChecker persoIDDuplicateChecker,
                                          IPersonRepository personRepository,
                                          IPersonIDUsedChecker personIDUsedChecker)
        {
            _personIDValidationChecker = personIDValidationChecker;
            _partIDIsValidChecker = partIDIsValidChecker;
            _persoIDDuplicateChecker = persoIDDuplicateChecker;
            _personRepository = personRepository;
            _personIDUsedChecker = personIDUsedChecker;
        }
        public void Execute(CreatePersonCommand command)
        {
            Person person = new Person(command.Name,
                                       command.PersonID,
                                       //command.CenterId,
                                       command.PartId,
                                       _personIDValidationChecker,
                                       _partIDIsValidChecker,
                                       _persoIDDuplicateChecker,
                                       _personIDUsedChecker);
            _personRepository.Add(person);
        }
    }
}
