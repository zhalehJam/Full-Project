namespace TicketContext.ReadModel.Query.Contracts.Programs.DataContracts
{
    public class ProgramSupporterDto
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int SupporterpersonID { get; set; }
        public string SupporterName { get; set; }
    }
}
