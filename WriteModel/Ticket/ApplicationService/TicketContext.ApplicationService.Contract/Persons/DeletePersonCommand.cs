using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Persons
{
    public class DeletePersonCommand:Command
    {
        public Guid Id { get; set; }
    }
}
