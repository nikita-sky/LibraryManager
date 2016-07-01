using LibraryManager.Data.EF.DatabaseContext;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;
using LibraryManager.Shared;
using LibraryManager.Shared.IoC;

namespace LibraryManager.Data.EF
{
    public class Bootsrapper: IBootsrapper
    {
        public void Execute(IServiceContainer container)
        {
            container.RegisterSingleton<LibraryManagerContext>();

            container.RegisterPerRequest<IRepository<Book>, BookRepository>();
            container.RegisterPerRequest<IRepository<LibraryCard>, LibraryCardRepository>();
            container.RegisterPerRequest<IRepository<ClientEntry>, ClientEntryRepository>();
        }
    }
}