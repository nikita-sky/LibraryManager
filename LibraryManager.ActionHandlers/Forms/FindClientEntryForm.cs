using System;

namespace LibraryManager.ActionHandlers.Forms
{
    public class FindClientEntryForm
    {
        public DateTime? TakedAt { get; set; }
        public DateTime? ReturnAt { get; set; }
        public string BookTitle { get; set; }
        public string ClientFullName { get; set; }
        public int Page { get; set; }
    }
}