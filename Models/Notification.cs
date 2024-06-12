using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class Notification: AuditedEntity<Guid>
{
    public string Type { get; set; }
    public DateTime SendAt { get; set; }
    public Guid MemberId { get; set; }

    public Member Member { get; set; }
}
