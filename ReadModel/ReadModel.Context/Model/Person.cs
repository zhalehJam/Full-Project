using TicketContext.Contract.Persons;

namespace ReadModel.Context.Model
{
    public partial class Person
    {
        public Guid Id { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; } = "";
        public Guid PartId { get; set; }
        public RoleType PersonRole{ get; set; }

    } 
}
