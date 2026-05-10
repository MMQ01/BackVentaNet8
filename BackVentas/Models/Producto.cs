using System;
using System.Collections.Generic;

namespace BackVentas.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public string SKU { get; set; } = null!;

    public decimal Stock { get; set; }

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();

    public virtual ICollection<ProductosFavorito> ProductosFavoritos { get; set; } = new List<ProductosFavorito>();

    public virtual ICollection<TmpCarrito> TmpCarritos { get; set; } = new List<TmpCarrito>();
}
