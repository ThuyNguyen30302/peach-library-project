using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Member
    {
        public Member()
        {
            CheckOuts = new HashSet<CheckOut>();
            Holds = new HashSet<Hold>();
            Notifications = new HashSet<Notification>();
            WaitingLists = new HashSet<WaitingList>();
        }

        public Guid Id { get; set; }
        public string? CardNumber { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<CheckOut> CheckOuts { get; set; }
        public virtual ICollection<Hold> Holds { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<WaitingList> WaitingLists { get; set; }
    }
}
