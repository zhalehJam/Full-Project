using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Persons
{
    public class UpdatePersonCommand:Command
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        //public Int32 PersonID { get; set; }
        public Guid CenterId { get; set; }
        public Guid PartId { get; set; }
    }
}
