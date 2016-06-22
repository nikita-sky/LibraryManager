using System.Data.Entity;
using System.Linq;
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
                .Include(x => x.Book.Title)
                .Include(x => x.Book.Id)
                .Include(x => x.LibraryCard.ClientFullName)
                .Include(x => x.LibraryCardId);
        }
    }
}