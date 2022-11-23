using System;
using Framework.Core.ApplicationService;

namespace Framework.ApplicationService
{
    public class Mediator : IMediator
    {
        public void SendMessage<Tcommand>(Tcommand command)
        {
            Console.WriteLine(command);
        }
    }
}
