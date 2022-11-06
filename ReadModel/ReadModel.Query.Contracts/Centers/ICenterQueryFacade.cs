using Framework.Core.Facade;
using PagedList;
using ReadModel.Query.Contracts.Centers.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.DataContracts;

namespace ReadModel.Query.Contracts.Centers
{
    public interface ICenterQueryFacade : IQueryFacade
    {
        List<CenterDto> GetCenters(string centerName = null);
        List<CenterDto> GetCentersByfilter(CenterQueryParameter centerQueryParameter=null);
        PagedList<CenterDto> GetCentersByPage(PageParametr centerQueryParameter);
    }
}
