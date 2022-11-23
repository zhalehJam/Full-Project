namespace Framework.Core.ApplicationService
{
    public interface ICollegue
    {
        void Send(string message);
        void Receive(string message);
    }
}
