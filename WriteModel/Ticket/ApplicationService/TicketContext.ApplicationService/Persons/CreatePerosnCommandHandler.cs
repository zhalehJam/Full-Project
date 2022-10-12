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
        private readonly IPersonRepository _personRepository;

        public CreatePerosnCommandHandler(IPersonIDValidationChecker personIDValidationChecker,
                                          IPartIDIsValidChecker partIDIsValidChecker,
                                          IPersonRepository personRepository)
        {
            _personIDValidationChecker = personIDValidationChecker;
            _partIDIsValidChecker = partIDIsValidChecker;
            _personRepository = personRepository;
        }
        public void Execute(CreatePersonCommand command)
        {
            Person person = new Person(command.Name,
                                       command.PersonID,
                                       command.CenterId,
                                       command.PartId,
                                       _personIDValidationChecker,
                                       _partIDIsValidChecker);
            _personRepository.Add(person);
        }
    }
}
