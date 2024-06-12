using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class BookCopy : AuditedEntity<Guid>
{
    public DateTime YearPublisher { get; set; }
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }

    public Book Book { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<CheckOut> CheckOuts { get; set; }
    public ICollection<Hold> Holds { get; set; }
}