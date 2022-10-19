using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers;
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

        public void AddProgramSupporter(ProgramSupporter supporterPerson)
        {
            ProgramSupporterDuplicateChecker(supporterPerson);
            ProgramSupporters.Add(supporterPerson);
        }

        private void ProgramSupporterDuplicateChecker(ProgramSupporter supporterPerson)
        {
            if(ProgramSupporters.Any(n => n.SupporterPersonID == supporterPerson.SupporterPersonID))
                throw new DuplicateProgramSupporerIDException();
        }

        public void DeleteProgramSupporter(Int32 programSupporterID)
        {
            var programSupporter = ProgramSupporters.Where(n => n.SupporterPersonID == programSupporterID).Select(n => n).FirstOrDefault();
            if(programSupporter==null)
                throw new InvalidProgramSupporterPersonIdException();
            ProgramSupporters.Remove(programSupporter);
        }

        public void UpdateProgramLink(string Link)
        {
            ProgramLink = Link;
        }

        public string ProgramName { get; private set; }
        public string ProgramLink { get; private set; }
        public ICollection<ProgramSupporter> ProgramSupporters { get; private set; } = new HashSet<ProgramSupporter>();

    }
}
