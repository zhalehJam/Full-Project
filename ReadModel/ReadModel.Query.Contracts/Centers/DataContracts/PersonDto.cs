namespace TicketContext.ReadModel.Query.Contracts.Centers.DataContracts
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public int PersonID { get; set; }
        public string? PersonName { get; set; }
        public Guid PartId { get; set; }
        public string? PartName { get; set; }
        public string? CenterName { get; set; }
    }

}
