using System;

namespace LibraryManager.ActionHandlers.ViewModels
{
    public class ClientEntryViewModel
    {
        public int Id { get; set; }
        public DateTime TakedAt { get; set; }
        public DateTime ReturnAt { get; set; }

        public BookViewModel Book { get; set; }
        public LibraryCardViewModel LibraryCard { get; set; }
    }
}