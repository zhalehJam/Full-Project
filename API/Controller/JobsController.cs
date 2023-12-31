using API.Jobs.Scheduler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly PersonCreatorJobScheduler _personCreatorJobScheduler;

        public JobsController(PersonCreatorJobScheduler personCreatorJobScheduler)
        {
            _personCreatorJobScheduler = personCreatorJobScheduler;
        }

        [HttpGet]
        public async Task<IActionResult> RunPersonCreatorJob()
        {
            await _personCreatorJobScheduler.CreateNewPersonsJobAsync();
            return Ok();
        }
    }
}
