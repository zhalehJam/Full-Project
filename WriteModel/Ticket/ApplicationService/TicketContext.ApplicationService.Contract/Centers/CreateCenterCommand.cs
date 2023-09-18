using Framework.Core.ApplicationService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.ApplicationService.Contract.Centers
{
    public class CreateCenterCommand : Command, IRequest<Guid>
    {
        public string? CenterName { get; set; }
        public int CenterID { get; set; }
    }
}
