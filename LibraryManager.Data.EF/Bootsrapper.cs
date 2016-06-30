using LibraryManager.Data.EF.DatabaseContext;
using LibraryManager.Shared;
using LightInject;

namespace LibraryManager.Data.EF
{
    public class Bootsrapper: IBootsrapper
    {
        public void Execute(IServiceContainer container)
        {
            container.Register<LibraryManagerContext>();
        }
    }
}