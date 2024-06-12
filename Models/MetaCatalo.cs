using System;
using System.Collections.Generic;
using PLP.Domain;

namespace PLP.Models;

public class MetaCatalo : AuditedEntity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

    public ICollection<Catalo> Catalos { get; set; }
}