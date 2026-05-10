using System;
using System.Collections.Generic;

namespace BackVentas.Models;

public partial class AsignacionCliente
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ClienteId { get; set; }

    public bool Estado { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
