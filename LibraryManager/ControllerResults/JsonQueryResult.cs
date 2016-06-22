using LibraryManager.ActionHandlers.Common;

namespace LibraryManager.ControllerResults
{
    public class JsonQueryResult<T>
    {
        public int Id { get; set; }
        public T[] Items { get; set; }
        public long Count { get; set; }
        public long Total { get; set; }

        public static JsonQueryResult<T> FromQueryResult(QueryResult<T> source)
            => new JsonQueryResult<T>()
            {
                Total = source.Total,
                Id = source.Id,
                Count = source.Count,
                Items = source.Items
            };
    }
}