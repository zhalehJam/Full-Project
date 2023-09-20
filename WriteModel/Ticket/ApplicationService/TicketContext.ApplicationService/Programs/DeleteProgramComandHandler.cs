using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Programs;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.ApplicationService.Programs
{
    public class DeleteProgramComandHandler : ICommandHandler<DeleteProgramCommand>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IProgramHasTicketChecker _programHasTicketChecker;

        public DeleteProgramComandHandler(IProgramRepository programRepository,
            IProgramHasTicketChecker programHasTicketChecker)
        {
            _programRepository = programRepository;
            _programHasTicketChecker = programHasTicketChecker;
        }

        public void Execute(DeleteProgramCommand command)
        {
            Program program = _programRepository.GetById(command.Id);
            program.CanDeleteProgram(_programHasTicketChecker);
            _programRepository.Delete(program);

        }
    }
}
