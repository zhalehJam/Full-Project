
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Pagination;
using ReadModel.Query.Contracts.Centers;
using ReadModel.Query.Contracts.Centers.DataContracts;
using System.Security.Claims;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Facade.Contract;
using TicketContext.ReadModel.Query.Contracts.DataContracts;

namespace API.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CenterController : ControllerBase
    {
        private readonly ICenterCommandFacade _centerCommandFacade;
        private readonly ICenterQueryFacade _centerQueryFacade;
       

        public CenterController(ICenterCommandFacade centerCommandFacade,
                                ICenterQueryFacade centerQueryFacade )
        {
            _centerCommandFacade = centerCommandFacade;
            _centerQueryFacade = centerQueryFacade; 
        }
        [HttpPost("CreateCenter")]
        public async Task<Guid> CreateCenter(CreateCenterCommand createCenterCommand)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if(User.IsInRole("TMS_User"))
            {
                var t= int.Parse(claimsIdentity.FindFirst("TMSCenterID").Value);
            }
            return await _centerCommandFacade.CreateCenter(createCenterCommand);
        }
        [HttpPut("AddPart")]
        public async Task AddPart(AddPartCommand addPartCommand)
        {
            await _centerCommandFacade.AddPart(addPartCommand);
        }

        [HttpPut("DeletePart")]
        public async Task DeletePart(DeletePartCommand deletePartCommand)
        {
           await _centerCommandFacade.DeletePart(deletePartCommand);
        }

        [HttpGet("GetAllCenters")]
        public IList<CenterDto> GetAllCencters()
        {
            return _centerQueryFacade.GetCenters();
        }
        [HttpGet("GetCenterByName")]
        public IList<CenterDto> GetCencterByName([FromQuery] string centerName)
        {
            return _centerQueryFacade.GetCenters(centerName: centerName);
        }
        [HttpGet("GetCenterByOtherFilters")]
        public IList<CenterDto> GetCenterByOtherFilters([FromQuery] CenterQueryParameter parameters)
        {
            return _centerQueryFacade.GetCentersByfilter(centerQueryParameter: parameters);
        }

        [HttpGet("GetCentersByPage")]
        public PagedList<CenterDto> GetCentersByPage([FromQuery] PageParameter parameters)
        {
            return _centerQueryFacade.GetCentersByPage(centerQueryParameter: parameters);
        }

        [HttpDelete]
        public async Task DeleteCenter(DeleteCenterCommand deleteCenterCommand)
        {
           await _centerCommandFacade.DeleteCenter(deleteCenterCommand);
        }

        [HttpPut("EditCenterName")]
        public async Task EditCenter(EditCenterCommand editCenterCommand)
        {
           await _centerCommandFacade.EditCenter(editCenterCommand);
        }

    }
}
