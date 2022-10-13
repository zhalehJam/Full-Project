using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.Domain.Services.Programs
{
    public class ProgramNameDuplicateChecker : IProgramNameDuplicateChecker
    {
        private readonly IProgramRepository _programRepository;

        public ProgramNameDuplicateChecker(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public bool IsDuplicated(string programName)
        {
            bool isDuplicated=false;
            if(_programRepository.IsExist(n=>n.ProgramName == programName))
            {
                isDuplicated=true;
            }
            return isDuplicated;
        }
    }
}