using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class BookCopy
    {
        public BookCopy()
        {
            CheckOuts = new HashSet<CheckOut>();
            Holds = new HashSet<Hold>();
        }

        public Guid Id { get; set; }
        public DateTime? YearPublisher { get; set; }
        public Guid? BookId { get; set; }
        public Guid? PublisherId { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<CheckOut> CheckOuts { get; set; }
        public virtual ICollection<Hold> Holds { get; set; }
    }
}
