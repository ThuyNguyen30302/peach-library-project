using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;
public class WaitingList : AuditedEntity<Guid>
{
    public Guid MemberId { get; set; }
    public Guid BookId { get; set; }

    public Book Book { get; set; }
    public Member Member { get; set; }
}