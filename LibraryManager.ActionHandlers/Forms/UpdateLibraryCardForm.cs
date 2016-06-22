using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ActionHandlers.Forms
{
    public class UpdateLibraryCardForm: CreateLibraryCardForm
    {
        [Required]
        public int Id { get; set; }
    }
}