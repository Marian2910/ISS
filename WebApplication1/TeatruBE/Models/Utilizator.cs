using System;
using System.Collections.Generic;

namespace TeatruBE.Models;

public partial class Utilizator
{
    public int UserId { get; set; }

    public string Nume { get; set; } = null!;

    public string Prenume { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Parola { get; set; } = null!;

    public virtual ICollection<Rezervare> Rezervares { get; set; } = new List<Rezervare>();
}
