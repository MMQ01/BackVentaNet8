using System;
using System.Collections.Generic;

namespace BackVentas.Modelos;

public partial class ProductosPedido
{
    public int Id { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
