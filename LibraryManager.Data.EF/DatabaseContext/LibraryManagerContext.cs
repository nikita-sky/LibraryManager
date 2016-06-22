using System.Data.Entity;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.Data.EF.DatabaseContext
{
    public class LibraryManagerContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<ClientEntry> ClientEntries { get; set; }

        public LibraryManagerContext()
            : base("LibraryManagerDb")
        {
            Configuration.AutoDetectChangesEnabled = false;
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}