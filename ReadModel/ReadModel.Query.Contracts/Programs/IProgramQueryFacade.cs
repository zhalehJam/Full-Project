using Framework.Core.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.Programs.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Programs
{
    public interface IProgramQueryFacade:IQueryFacade
    {
        List<ProgramDto> GetAllPrograms();
        ProgramDto GetProgramById(Guid id);
        List<ProgramDto> GetSupporterProgramsList(int supporterCode);
    }
}
