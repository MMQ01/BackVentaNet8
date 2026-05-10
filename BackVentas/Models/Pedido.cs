using System;
using System.Collections.Generic;

namespace BackVentas.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public decimal Total { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public string? Origen { get; set; }

    public int IdUsuario { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
