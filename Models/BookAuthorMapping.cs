using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class BookAuthorMapping : Entity<Guid>
{
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public Author Author { get; set; }
    public Book Book { get; set; }
}
