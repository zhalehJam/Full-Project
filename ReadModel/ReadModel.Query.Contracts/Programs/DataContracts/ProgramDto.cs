namespace TicketContext.ReadModel.Query.Contracts.Programs.DataContracts
{
    public class ProgramDto
    {
        public ProgramDto()
        { }
        public Guid Id { get; set; }
        public string ProgamName { get; set; }
        public string ProgramLink { get; set; }
        public List<ProgramSupporterDto> Supporters { get; set; }
    }
}
