using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Notification
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime? SendAt { get; set; }
        public Guid? MemberId { get; set; }

        public virtual Member? Member { get; set; }
    }
}
