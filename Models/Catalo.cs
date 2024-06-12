using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class Catalo : Entity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string DisplayIndex { get; set; }
    public string MetaCataloCode { get; set; }
    public Guid MetaCataloId { get; set; }

    public MetaCatalo MetaCatalo { get; set; }
}
