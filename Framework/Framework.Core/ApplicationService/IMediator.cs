namespace Framework.Core.ApplicationService
{
    public interface IMediator
    {
        void SendMessage<Tcommand>(Tcommand command);
    }
}
