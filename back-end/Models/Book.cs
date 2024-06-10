using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthorMappings = new HashSet<BookAuthorMapping>();
            BookCopies = new HashSet<BookCopy>();
            WaitingLists = new HashSet<WaitingList>();
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }
        public virtual ICollection<WaitingList> WaitingLists { get; set; }
    }
}
