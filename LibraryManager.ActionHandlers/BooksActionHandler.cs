using System;
using System.Linq;
using AutoMapper;
using LibraryManager.ActionHandlers.Common;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.ActionHandlers.ViewModels;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.ActionHandlers
{
    public class BooksActionHandler: ActionHandler<Book>
    {
        public BooksActionHandler(IRepository<Book> repository, IMapper mapper)
            : base(repository, mapper)
        {
            
        }

        public QueryResult<Book> Find(string title, int page = 1)
        {
            page = Math.Max(1, page);
            var toSkip = (page - 1)*PageSize;

            var query = Repository.Query()
                .Where(x => x.Title.Contains(title));

            var total = query.LongCount();

            query = query.OrderBy(x => x.Title)
                .Skip(toSkip)
                .Take(PageSize);

            return QueryResult<Book>.Success(query.ToArray(), total);
        }

        public BookViewModel[] Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new BookViewModel[0];

            query = query.ToLower();

            return Repository.Query()
                .OrderBy(x => x.Title)
                .Where(x => x.Title.StartsWith(query))
                .Take(SearchResultCount)
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToArray();
        }

        public QueryResult<Book> Create(CreateBookForm form)
        {
            if (form == null)
                throw  new ArgumentNullException(nameof(form));

            return Add(Map<Book>(form));
        }

        public HandledActionResult Update(UpdateBookForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            return Update(Map<Book>(form));
        }
    }
}