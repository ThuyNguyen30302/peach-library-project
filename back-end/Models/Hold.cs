using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Hold
    {
        public Guid Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? BookCopyId { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual BookCopy? BookCopy { get; set; }
        public virtual Member? Member { get; set; }
    }
}
