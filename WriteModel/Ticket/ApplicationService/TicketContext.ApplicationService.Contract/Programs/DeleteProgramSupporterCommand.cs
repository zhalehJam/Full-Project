using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Programs
{
    public class DeleteProgramSupporterCommand : Command
    {
        public Guid ProgramId { get; set; }
        public Int32 SupporterID { get; set; }
    }
}
