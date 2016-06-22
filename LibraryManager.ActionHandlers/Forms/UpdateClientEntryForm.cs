using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ActionHandlers.Forms
{
    public class UpdateClientEntryForm: CreateClientEntryForm
    {
        [Required]
        public int Id { get; set; }
    }
}