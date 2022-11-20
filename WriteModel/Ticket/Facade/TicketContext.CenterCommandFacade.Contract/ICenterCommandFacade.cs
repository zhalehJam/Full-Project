using TicketContext.ApplicationService.Contract.Centers;

namespace TicketContext.Facade.Contract
{
    public interface ICenterCommandFacade
    {
        void CeateCenter(CreateCenterCommand createCenterCommand);
        void AddPart(AddPartCommand addPartCommand);
        void DeletePart(DeletePartCommand deletePartCommand);
        void DeleteCenter(DeleteCenterCommand deleteCenterCommand); 
        void EditCenter(EditCenterCommand editCenterCommand);
    }
}