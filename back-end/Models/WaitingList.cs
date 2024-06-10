using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class WaitingList
    {
        public Guid Id { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? BookId { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Member? Member { get; set; }
    }
}
