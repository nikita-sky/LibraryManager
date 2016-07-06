using System.Data.Entity;
using System.Linq;
using LibraryManager.Data.EF.DatabaseContext;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.Data.EF
{
    public class ClientEntryRepository: Repository<ClientEntry>
    {
        protected override DbSet<ClientEntry> DbSet
            => Context.ClientEntries;

        public override IQueryable<ClientEntry> Query()
        {
            return DbSet
                .Include(x => x.Book)
                .Include(x => x.LibraryCard);
        }

        public ClientEntryRepository(LibraryManagerContext context) : base(context)
        {
        }
    }
}