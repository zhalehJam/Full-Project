using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class EditCenterCommand:Command
    {
        public Guid Id  { get; set; }
        public string Name { get; set; }
    }
}
