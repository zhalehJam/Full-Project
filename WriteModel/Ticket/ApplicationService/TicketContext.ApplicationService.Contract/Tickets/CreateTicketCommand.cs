using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Contract.Tickets;

namespace TicketContext.ApplicationService.Contract.Tickets
{
    public class CreateTicketCommand : Command
    {
        public int SupporterPersonID { get; set; }
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
