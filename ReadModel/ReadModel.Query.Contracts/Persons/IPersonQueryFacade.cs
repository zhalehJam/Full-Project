using Framework.Core.Facade;
using PagedList;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Persons
{
    public interface IPersonQueryFacade : IQueryFacade
    {
        List<PersonDto> GetAllPersons();
        PersonDto GetPersonById(Guid Id);
        PagedList<PersonDto> GetAllPersonsByPage(PageParametr centerQueryParameter);

    }
}
