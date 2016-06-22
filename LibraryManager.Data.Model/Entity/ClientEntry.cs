using System;

namespace LibraryManager.Data.Model.Entity
{
    public class ClientEntry: EntityBase
    {
        public DateTime TakedAt { get; set; }
        public DateTime ReturnAt { get; set; }

        public int LibraryCardId { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}