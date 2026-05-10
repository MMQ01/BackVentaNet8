namespace BackVentas.Clases
{
    public partial class Categoria { public int Id { get; set; } public string Nombre { get; set; } = null!; }
    public partial class Cliente { public int Id { get; set; } public string Nombre { get; set; } = null!; public string? Direccion { get; set; } public string Nit { get; set; } = null!; public bool Estado { get; set; } }
    public partial class Pedido { public int Id { get; set; } public int IdCliente { get; set; } public decimal Total { get; set; } public DateTime FechaCreacion { get; set; } public bool? Estado { get; set; } public string? Origen { get; set; } public int IdUsuario { get; set; } }
    public partial class PedidoDetalle { public int Id { get; set; } public int IdPedido { get; set; } public int IdProducto { get; set; } public decimal Cantidad { get; set; } public decimal Precio { get; set; } }
    public partial class Producto { public int Id { get; set; } public string? Nombre { get; set; } public decimal? Precio { get; set; } public string? Descripcion { get; set; } public bool? Estado { get; set; } public string Sku { get; set; } = null!; public decimal Stock { get; set; } }
    public partial class Usuario { public int Id { get; set; } public string Nombres { get; set; } = null!; public string Apellidos { get; set; } = null!; public string Login { get; set; } = null!; public string Contrasena { get; set; } = null!; public bool Estado { get; set; } public int Categoria { get; set; } }
    public partial class AsignacionCliente { public int Id { get; set; } public int UsuarioId { get; set; } public int ClienteId { get; set; } public bool Estado { get; set; } }
    public partial class ProductosFavorito { public int Id { get; set; } public int UsuarioId { get; set; } public int ProductoId { get; set; } }
    public partial class TmpCarrito { public int Id { get; set; } public int UsuarioId { get; set; } public int ProductoId { get; set; } public double Cantidad { get; set; } }
}
