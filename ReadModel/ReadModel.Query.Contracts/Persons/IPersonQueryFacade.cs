using Framework.Core.Facade;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Persons
{
    public interface IPersonQueryFacade : IQueryFacade
    {
        List<PersonDto> GetAllPersons();
        PersonDto GetPersonById(Guid Id);
    }
}
