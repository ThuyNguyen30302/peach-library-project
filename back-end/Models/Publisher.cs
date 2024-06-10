using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            BookCopies = new HashSet<BookCopy>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}
