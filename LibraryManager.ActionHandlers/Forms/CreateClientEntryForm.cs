using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ActionHandlers.Forms
{
    public class CreateClientEntryForm
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int LibraryCardId { get; set; }

        [Required]
        public DateTime TakedAt { get; set; }

        [Required]
        public DateTime ReturnAt { get; set; }

        public bool IsValid => TakedAt < ReturnAt;
        public bool IsInvalid => !IsValid;
    }
}