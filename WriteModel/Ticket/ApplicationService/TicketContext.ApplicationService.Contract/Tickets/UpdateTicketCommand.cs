﻿using Framework.Core.ApplicationService;
using TicketContext.Contract.Tickets;

namespace TicketContext.ApplicationService.Contract.Tickets
{
    public class UpdateTicketCommand : Command
    {
        public Guid Id { get; set; }
        public int EditorPersonID { get; set; }
        public int PersonID { get; set; }
        public Guid ProgramId { get; set; }
        public ErrorType ErrorType { get; set; }
        public TicketType Type { get; set; }
        public string ErrorDiscription { get; set; }
        public string SolutionDiscription { get; set; }
        public DateTime TicketTime { get; set; }
        public TicketCondition TicketCondition { get; set; }
    }
}
