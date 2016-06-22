using System.Data.Entity;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.Data.EF
{
    public class BookRepository: Repository<Book>
    {
        protected override DbSet<Book> DbSet
            => Context.Books;
    }
}