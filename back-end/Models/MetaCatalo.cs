using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class MetaCatalo
    {
        public MetaCatalo()
        {
            Catalos = new HashSet<Catalo>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<Catalo> Catalos { get; set; }
    }
}
