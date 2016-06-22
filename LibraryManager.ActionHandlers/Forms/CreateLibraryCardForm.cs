using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ActionHandlers.Forms
{
    public class CreateLibraryCardForm
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}