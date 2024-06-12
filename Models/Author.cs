using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class Author : AuditedEntity<Guid>
{
    public string Name { get; set; }
    public string NickName { get; set; }

    public ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
}