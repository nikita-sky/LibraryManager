using System;
using System.Linq;
using AutoMapper;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.ActionHandlers.Common
{
    public class ActionHandler<T> where T: EntityBase
    {
        public const int PageSize = 10;
        public const int SearchResultCount = 5;

        protected IRepository<T> Repository { get; }
        protected IMapper Mapper { get; }

        protected ActionHandler(IRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual QueryResult<T> Get(int page)
        {
            page = Math.Max(1, page);
            var toSkip = (page - 1) * PageSize;
            var items = Repository.Query()
                .OrderBy(x => x.Id)
                .Skip(toSkip)
                .Take(PageSize)
                .ToArray();

            return QueryResult<T>.Success(items, Repository.Total());
        }

        public QueryResult<T> Add(T entity)
        {
            Repository.Add(entity);
            return new QueryResult<T>(HandledActionResultCode.Success)
            {
                Id = entity.Id,
                Count = 1,
                Total = Repository.Total()
            };
        }

        public HandledActionResult Update(T entity)
        {
            Repository.Update(entity);
            return HandledActionResult.Success;
        }

        public QueryResult<int> Delete(int id)
        {
            Repository.Delete(id);
            return new QueryResult<int>(HandledActionResultCode.Success)
            {
                Id = id,
                Count = 1,
                Total = Repository.Total()
            };
        }

        protected TDestination Map<TDestination>(object source)
            => Mapper.Map<TDestination>(source);
    }
}