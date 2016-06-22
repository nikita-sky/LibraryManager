using LightInject;

namespace LibraryManager.Shared
{
    public interface IBootsrapper
    {
        void Execute(IServiceContainer container);
    }
}