using TicketContext.ApplicationService.Contract.Persons;

namespace TicketContext.Facade.Contract
{
    public interface IPersonCommandFacade
    {
        void CreatePerson(CreatePersonCommand createPersonCommand);
        void UpdatePerson(UpdatePersonCommand updatePersonCommand);
        void DeletePerson(DeletePersonCommand deletePersonCommand);
    }
}