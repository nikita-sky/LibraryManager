using System.Data.Entity;
using LibraryManager.Data.EF.DatabaseContext;
using LibraryManager.Data.EF.Migrations;
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryManagerContext, Configuration>());

            container.RegisterSingleton<LibraryManagerContext>();

            container.RegisterPerRequest<IRepository<Book>, BookRepository>();
            container.RegisterPerRequest<IRepository<LibraryCard>, LibraryCardRepository>();
            container.RegisterPerRequest<IRepository<ClientEntry>, ClientEntryRepository>();
        }
    }
}