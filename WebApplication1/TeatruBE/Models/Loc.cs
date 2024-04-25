using System;
using System.Collections.Generic;

namespace TeatruBE.Models;

public partial class Loc
{
    public int LocId { get; set; }

    public int? TipLocId { get; set; }

    public string? Stare { get; set; }

    public int? SpectacolId { get; set; }

    public virtual Spectacol? Spectacol { get; set; }

    public virtual TipLoc? TipLoc { get; set; }

    public virtual ICollection<Rezervare> Rezervares { get; set; } = new List<Rezervare>();
}
