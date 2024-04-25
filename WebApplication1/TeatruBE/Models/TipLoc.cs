using System;
using System.Collections.Generic;

namespace TeatruBE.Models;

public partial class TipLoc
{
    public int TipLocId { get; set; }

    public string? Nume { get; set; }

    public decimal? Pret { get; set; }

    public virtual ICollection<Loc> Locs { get; set; } = new List<Loc>();
}
