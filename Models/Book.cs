using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class Book : AuditedEntity<Guid>
{
    public string Title { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }

    public ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
    public ICollection<BookCopy> BookCopies { get; set; }
    public ICollection<WaitingList> WaitingLists { get; set; }
}