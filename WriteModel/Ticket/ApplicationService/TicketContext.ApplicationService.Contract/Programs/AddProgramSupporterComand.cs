﻿using Framework.Core.ApplicationService;

namespace TicketContext.ApplicationService.Contract.Program
{
    public class AddProgramSupporterCommand:Command
    {
        public Guid ProgramId { get; set; }
        public Int32 SupporterID { get; set; }  
    }
}