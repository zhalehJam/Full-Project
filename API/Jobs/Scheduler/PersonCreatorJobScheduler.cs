using Hangfire;

namespace API.Jobs.Scheduler
{
    public class PersonCreatorJobScheduler
    {
        private readonly IRecurringJobManager recurringJobManager;
        private readonly PersonCreatorService personCreatorService;


        public PersonCreatorJobScheduler(IRecurringJobManager recurringJobManager, PersonCreatorService personCreatorService)
        {
            this.recurringJobManager = recurringJobManager;
            this.personCreatorService = personCreatorService;
        }

        public Task CreateNewPersonsJobAsync()
        {
            recurringJobManager.AddOrUpdate("CreateNewPersonsJob", () => personCreatorService.CreateNewPersonsAsync(), "0 * * * *");
            return Task.CompletedTask;
        }
    }
}
