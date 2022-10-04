namespace Framework.Core.DependencyInjection
{
    public interface IDIContainer
    {
        T Resolve<T>();
    }
}