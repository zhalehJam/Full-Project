using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Programs;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.ApplicationService.Programs
{
    public class AddProgramSupporterComandHandler : ICommandHandler<AddProgramSupporterCommand>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IValidSupporterPersonIDChecker _validSupporterPersonIDChecker;

        public AddProgramSupporterComandHandler(IProgramRepository programRepository, IValidSupporterPersonIDChecker validSupporterPersonIDChecker)
        {
            _programRepository = programRepository;
            _validSupporterPersonIDChecker = validSupporterPersonIDChecker;
        }
        public void Execute(AddProgramSupporterCommand command)
        {
            Program program= _programRepository.GetById(command.ProgramId);
            ProgramSupporter programSupporter = new ProgramSupporter(command.SupporterID,
                                                                     _validSupporterPersonIDChecker);
            program.AddProgramSupporter(programSupporter);
            _programRepository.Update(program);
        }
    }
}
