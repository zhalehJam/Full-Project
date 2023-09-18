using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Program;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.ApplicationService.Programs
{
    public class AddProgramSupporterCommandHandler : ICommandHandler<AddProgramSupporterCommand>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IValidSupporterPersonIDChecker _validSupporterPersonIdChecker;

        public AddProgramSupporterCommandHandler(IProgramRepository programRepository,
                                                IValidSupporterPersonIDChecker validSupporterPersonIdChecker)
        {
            _programRepository = programRepository;
            _validSupporterPersonIdChecker = validSupporterPersonIdChecker;
        }
        public void Execute(AddProgramSupporterCommand command)
        {
            Program program= _programRepository.GetById(command.ProgramId);
            ProgramSupporter programSupporter = new ProgramSupporter(command.SupporterID,
                                                                     _validSupporterPersonIdChecker);
            program.AddProgramSupporter(programSupporter);
            _programRepository.Update(program);
        }
    }
}
