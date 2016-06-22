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

        protected IRepository<T> Repository { get; }
        protected IMapper Mapper { get; }

        protected ActionHandler(IRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public QueryResult<T> Get(int page)
        {
            try
            {
                page = Math.Max(1, page);
                var toSkip = (page - 1) * PageSize;
                var items = Repository.Query()
                    .Skip(toSkip)
                    .Take(PageSize)
                    .ToArray();

                return QueryResult<T>.Success(items, Repository.Total());
            }
            catch (Exception)
            {
                return QueryResult<T>.Failure();
            }
        }

        public QueryResult<T> Add(T entity)
        {
            try
            {
                Repository.Add(entity);
                return new QueryResult<T>(HandledActionResultCode.Success)
                {
                    Id = entity.Id,
                    Count = 1,
                    Total = Repository.Total()
                };
            }
            catch (Exception)
            {
                return QueryResult<T>.Failure();
            }
        }

        public HandledActionResult Update(T entity)
        {
            try
            {
                Repository.Update(entity);
                return HandledActionResult.Success;
            }
            catch (Exception)
            {
                return HandledActionResult.Failure;
            }
        }

        public QueryResult<int> Delete(int id)
        {
            try
            {
                Repository.Delete(id);
                return new QueryResult<int>(HandledActionResultCode.Success)
                {
                    Id = id,
                    Count = 1,
                    Total = Repository.Total()
                };
            }
            catch (Exception)
            {
                return QueryResult<int>.Failure();
            }
        }

        protected TDestination Map<TDestination>(object source)
            => Mapper.Map<TDestination>(source);
    }
}