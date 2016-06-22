using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ActionHandlers.Forms
{
    public class CreateBookForm
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Isbn { get; set; }
    }
}