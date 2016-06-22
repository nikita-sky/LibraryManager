using System;
using System.Linq;
using AutoMapper;
using LibraryManager.ActionHandlers.Common;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.ActionHandlers
{
    public class LibraryCardActionHandler: ActionHandler<LibraryCard>
    {
        public LibraryCardActionHandler(IRepository<LibraryCard> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public QueryResult<LibraryCard> Find(string fullName, int page = 1)
        {
            page = Math.Max(1, page);
            var toSkip = (page - 1)*PageSize;

            var query = Repository.Query().Where(x => x.ClientFullName.StartsWith(fullName));
            var total = query.LongCount();

            query = query.OrderBy(x => x.ClientFullName)
                .Skip(toSkip)
                .Take(PageSize);

            return QueryResult<LibraryCard>.Success(query.ToArray(), total);
        }

        public QueryResult<LibraryCard> Create(CreateLibraryCardForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            return Add(Map<LibraryCard>(form));
        }

        public HandledActionResult Update(UpdateLibraryCardForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            return Update(Map<LibraryCard>(form));
        }
    }
}