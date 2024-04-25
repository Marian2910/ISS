using System;
using System.Collections.Generic;

namespace TeatruBE.Models;

public partial class Sala
{
    public int SalaId { get; set; }

    public string? Nume { get; set; }

    public int? NumarLocuri { get; set; }
}
