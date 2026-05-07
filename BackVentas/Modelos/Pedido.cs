using System;
using System.Collections.Generic;

namespace BackVentas.Modelos;

public partial class Pedido
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public decimal Total { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ProductosPedido> ProductosPedidos { get; set; } = new List<ProductosPedido>();
}
