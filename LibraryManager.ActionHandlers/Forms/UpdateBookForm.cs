using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ActionHandlers.Forms
{
    public class UpdateBookForm: CreateBookForm
    {
        [Required]
        public int Id { get; set; }
    }
}