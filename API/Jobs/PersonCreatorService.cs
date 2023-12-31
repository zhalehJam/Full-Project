using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.ApplicationService.Contract.Persons;
using TicketContext.Facade.Contract;

namespace API.Jobs
{
    public class PersonCreatorService
    {
        private readonly IPersonCommandFacade personCommandFacade;
        public PersonCreatorService(IPersonCommandFacade personCommandFacade)
        {
            this.personCommandFacade = personCommandFacade;
        }
        
        public async Task CreateNewPersonsAsync()
        {
            var newPerson = new List<CreatePersonCommand>();

            if (newPerson.Exists(_ => true))
            {
                foreach (var person in newPerson)
                {
                    personCommandFacade.CreatePerson(person);
                }
            }
        }
    }
}
