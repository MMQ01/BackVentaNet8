using System;
using System.Collections.Generic;

namespace BackVentas.Modelos;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<ProductosPedido> ProductosPedidos { get; set; } = new List<ProductosPedido>();
}
