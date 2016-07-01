using LibraryManager.Shared.IoC;

namespace LibraryManager.Shared
{
    public interface IBootsrapper
    {
        void Execute(IServiceContainer container);
    }
}