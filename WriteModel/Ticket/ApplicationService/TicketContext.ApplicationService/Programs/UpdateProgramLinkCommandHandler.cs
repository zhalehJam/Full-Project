using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Programs;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.ApplicationService.Programs
{
    public class UpdateProgramLinkCommandHandler : ICommandHandler<UpdateProgramLinkCommand>
    {
        private readonly IProgramRepository _programRepository;

        public UpdateProgramLinkCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public void Execute(UpdateProgramLinkCommand command)
        {
            Program program = _programRepository.GetById(command.Id);
            program.UpdateProgramLink(command.ProgramLink);
            _programRepository.Update(program);
        }
    }
}
