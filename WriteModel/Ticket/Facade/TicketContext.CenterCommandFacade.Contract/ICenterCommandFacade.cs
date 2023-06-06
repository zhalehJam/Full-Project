using TicketContext.ApplicationService.Contract.Centers;

namespace TicketContext.Facade.Contract
{
    public interface ICenterCommandFacade
    {
        Task<Guid> CreateCenter(CreateCenterCommand createCenterCommand);
        Task AddPart(AddPartCommand addPartCommand);
        Task DeletePart(DeletePartCommand deletePartCommand);
        Task DeleteCenter(DeleteCenterCommand deleteCenterCommand);
        Task EditCenter(EditCenterCommand editCenterCommand);
    }
}