using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthorMappings = new HashSet<BookAuthorMapping>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
    }
}
