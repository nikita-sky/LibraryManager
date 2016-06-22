namespace LibraryManager.ActionHandlers.Common
{
    public class QueryResult<T>: HandledActionResult
    {
        public int Id { get; set; }
        public long Count { get; set; }
        public T[] Items { get; set; }
        public long Total { get; set; }

        public QueryResult(HandledActionResultCode code)
            : base(code)
        {
        }

        public new static QueryResult<T> Success(T[] data, long total)
            => new QueryResult<T>(HandledActionResultCode.Success)
                {
                    Total =  total,
                    Items = data,
                    Count = data.Length
                };

        public new static QueryResult<T> Failure()
            => new QueryResult<T>(HandledActionResultCode.Failure);

        public new static QueryResult<T> NotFound()
            => new QueryResult<T>(HandledActionResultCode.NotFound);

        public new static QueryResult<T> BadRequest() => new QueryResult<T>(HandledActionResultCode.BadRequest);

        public new static QueryResult<T> Forbidden() => new QueryResult<T>(HandledActionResultCode.Forbidden);
    }
}