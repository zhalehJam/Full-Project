namespace ReadModel.Context.Model
{
    public partial class Part
    {
        public Guid Id { get; set; }
        public Guid Center { get; set; }
        public string PartName { get; set; }
        public int PartID { get; set; }
        public virtual Center Centers { get; set; }
    }
}
