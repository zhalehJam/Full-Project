namespace ReadModel.Context.Model
{
    public partial class Program
    {
        public Program()
        {
            Supporters = new HashSet<ProgramSupporter>();
        }
        public Guid Id { get; set; }
        public string ProgramName { get; set; }
        public string ProgramLink { get; set; }
        public virtual ICollection<ProgramSupporter> Supporters { get; set; }
    }
}
