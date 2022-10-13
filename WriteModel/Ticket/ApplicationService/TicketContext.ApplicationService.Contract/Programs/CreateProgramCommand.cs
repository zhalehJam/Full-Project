using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.ApplicationService.Contract.Program
{
    public class CreateProgramCommand : Command
    {

        public string ProgramName { get; set; }
        public string ProgramLink { get; set; }
    }
}
