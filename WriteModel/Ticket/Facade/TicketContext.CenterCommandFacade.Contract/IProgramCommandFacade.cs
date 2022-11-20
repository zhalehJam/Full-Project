using TicketContext.ApplicationService.Contract.Program;

namespace TicketContext.Facade.Contract
{
    public interface IProgramCommandFacade
    {
        void CreateProgram(CreateProgramCommand createProgramCommand);
        void UpdateProgramlink(UpdateProgramLinkCommand updateProgramLinkCommand);
        void AddProgramSupporter(AddProgramSupporterCommand addProgramSupporterCommand);
        void DeleteProgramSupporter(DeleteProgramSupporterCommand deleteProgramSupporterCommand);
        void DeleteProgram(DeleteProgramCommand deleteProgramCommand);
    }
}