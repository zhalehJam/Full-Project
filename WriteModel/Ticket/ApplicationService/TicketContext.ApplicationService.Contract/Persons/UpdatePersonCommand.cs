using Framework.Core.ApplicationService;
using TicketContext.Contract.Persons;

namespace TicketContext.ApplicationService.Contract.Persons
{
    public class UpdatePersonCommand:Command
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public Guid PartId { get; set; }
        public RoleType PersonRole{ get; set; }
    }
}
