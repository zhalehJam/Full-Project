﻿namespace ReadModel.Context.Model
{
    public partial class ProgramSupporter
    {
        public Guid Id { get; set; }
        public Guid Program { get; set; }
        public int SupporterPersonID { get; set; }
        public virtual Program Programs { get; set; }
    }
}