using TicketContext.Contract.Tickets;

namespace ReadModel.Context.Model
{
    public partial class Ticket
    {
        public Guid Id { get; set; }
        public int PersonID { get; set; }
        public Guid PersonPartId { get; set; }
        public Guid ProgramId { get; set; }
        public ErrorType ErrorType { get; set; }
        public TicketType Type { get; set; }
        public string? ErrorDescription { get; set; }
        public string? SolutionDescription { get; set; }
        public DateTime TicketTime { get; set; }
        public TicketCondition TicketCondition { get; set; }
        public int SupporterPersonId { get; set; }
    }
}