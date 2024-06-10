using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class BookAuthorMapping
    {
        public Guid Id { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? BookId { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Book? Book { get; set; }
    }
}
