using System.Data.Entity;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.Data.EF
{
    public class LibraryCardRepository: Repository<LibraryCard>
    {
        protected override DbSet<LibraryCard> DbSet
            => Context.LibraryCards;
    }
}