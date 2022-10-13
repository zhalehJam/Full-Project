using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Programs.Exceptions;

namespace TicketContext.Domain.Programs
{
    public class Program : EntityBase, IAggregateRoot
    {
        private readonly IProgramNameDuplicateChecker _programNameDuplicateChecker;

        public Program(string programName,
                       string programLink,
                       IProgramNameDuplicateChecker programNameDuplicateChecker)
        {
            _programNameDuplicateChecker = programNameDuplicateChecker;
            SetProgramName(programName);
            ProgramLink = programLink;
        }
        protected Program()
        {

        }

        private void SetProgramName(string programName)
        {
            if(string.IsNullOrWhiteSpace(programName))
                throw new NullOrWhiteProgramNameException();
            if(_programNameDuplicateChecker.IsDuplicated(programName))
                throw new ProgramNameIsDupliateException();

            ProgramName = programName;
        }

        public void UpdateProgramLink(string Link)
        {
            ProgramLink = Link;
        }

        public string ProgramName { get; private set; }
        public string ProgramLink { get; private set; }
    }
}
