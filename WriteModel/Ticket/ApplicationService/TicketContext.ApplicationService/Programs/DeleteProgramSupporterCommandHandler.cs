using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Programs;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.ApplicationService.Programs
{
    public class DeleteProgramSupporterCommandHandler : ICommandHandler<DeleteProgramSupporterCommand>
    {
        private readonly IProgramRepository _programRepository;

        public DeleteProgramSupporterCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public void Execute(DeleteProgramSupporterCommand command)
        {
            Program program = _programRepository.GetById(command.ProgramId);
            program.DeleteProgramSupporter(command.SupporterID);
            _programRepository.Update(program);
        }
    }
}
