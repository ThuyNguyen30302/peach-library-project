using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class Publisher : AuditedEntity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ICollection<BookCopy> BookCopies { get; set; }
}
