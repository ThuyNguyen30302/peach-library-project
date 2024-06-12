using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class Hold : AuditedEntity<Guid>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookCopyId { get; set; }

    public BookCopy BookCopy { get; set; }
    public Member Member { get; set; }
}
