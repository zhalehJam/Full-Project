using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.ApplicationService.Programs
{
    public class CreateProgramCommandHandler : ICommandHandler<CreateProgramCommand>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IProgramNameDuplicateChecker _programNameDuplicateChecker;
        private readonly IProgramHasTicketChecker _programHasTicketChecker;

        public CreateProgramCommandHandler(IProgramRepository programRepository,
                                           IProgramNameDuplicateChecker programNameDuplicateChecker,
                                           IProgramHasTicketChecker programHasTicketChecker)
        {
            _programRepository = programRepository;
            _programNameDuplicateChecker = programNameDuplicateChecker;
            _programHasTicketChecker = programHasTicketChecker;
        }
        public void Execute(CreateProgramCommand command)
        {
            Program program = new Program(command.ProgramName,
                                          command.ProgramLink,
                                          _programNameDuplicateChecker,
                                          _programHasTicketChecker);

            _programRepository.Add(program);
        }
    }
}
