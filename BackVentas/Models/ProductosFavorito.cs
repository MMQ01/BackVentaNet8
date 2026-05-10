using System;
using System.Collections.Generic;

namespace BackVentas.Models;

public partial class ProductosFavorito
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
