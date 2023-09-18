using Framework.Core.ApplicationService;
using TicketContext.Contract.Persons;

namespace TicketContext.ApplicationService.Contract.Persons
{
    public class CreatePersonCommand : Command
    {
        public string? Name { get; set; }
        public Int32 PersonID { get; set; } 
        public Guid PartId { get; set; }
        public RoleType PersonRoleType{ get; set; }
    }
}
