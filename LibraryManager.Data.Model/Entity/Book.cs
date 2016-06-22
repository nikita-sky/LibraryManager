namespace LibraryManager.Data.Model.Entity
{
    public class Book: EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
    }
}