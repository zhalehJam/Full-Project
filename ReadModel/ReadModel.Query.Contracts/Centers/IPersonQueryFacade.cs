using Framework.Core.Facade;
using TicketContext.ReadModel.Query.Contracts.Centers.DataContracts;

namespace ReadModel.Query.Contracts.Centers
{
    public interface IPersonQueryFacade:IQueryFacade
    {
        List<PersonDto> GetAllPersons();
        PersonDto GetPersonById(Guid Id);
    }
}
