using System;
using System.Collections.Generic;

namespace PLP.Models
{
    public partial class Catalo
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? DisplayIndex { get; set; }
        public string? MetaCataloCode { get; set; }
        public Guid? MetaCataloId { get; set; }

        public virtual MetaCatalo? MetaCatalo { get; set; }
    }
}
