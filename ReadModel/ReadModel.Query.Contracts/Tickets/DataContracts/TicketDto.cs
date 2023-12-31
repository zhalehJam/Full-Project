using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Contract.Tickets;

namespace TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public Guid PersonPartId { get; set; }
        public Guid PersonCenterId { get; set; }
        public string PersonPartName { get; set; }
        public string PersonCenterName { get; set; }
        public Guid ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int ErrorTypeid { get; set; }
        public string ErrorTypeName { get; set; }
        public int Typeid { get; set; }
        public string TicketTypeName { get; set; }
        public string? ErrorDiscription { get; set; }
        public string? SolutionDiscription { get; set; }
        public DateTime TicketTime { get; set; }
        public int TicketConditionid { get; set; }
        public string TicketConditionTypeName { get; set; }
        public int SupporterPersonID { get; set; }
        public string SupporterPersonName { get; set; }
    }
}
