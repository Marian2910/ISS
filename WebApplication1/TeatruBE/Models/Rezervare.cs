using System;
using System.Collections.Generic;

namespace TeatruBE.Models;

public partial class Rezervare
{
    public int RezervareId { get; set; }

    public int? UserId { get; set; }

    public int? SpectacolId { get; set; }

    public virtual Spectacol? Spectacol { get; set; }

    public virtual Utilizator? User { get; set; }

    public virtual ICollection<Loc> Locs { get; set; } = new List<Loc>();
}
