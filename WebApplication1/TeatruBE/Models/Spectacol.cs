using System;
using System.Collections.Generic;

namespace TeatruBE.Models;

public partial class Spectacol
{
    public int SpectacolId { get; set; }

    public string? Nume { get; set; }

    public DateTime? Data { get; set; }

    public TimeSpan? Ora { get; set; }

    public int? NumarLocuri { get; set; }

    public virtual ICollection<Loc> Locs { get; set; } = new List<Loc>();

    public virtual ICollection<Rezervare> Rezervares { get; set; } = new List<Rezervare>();
}
