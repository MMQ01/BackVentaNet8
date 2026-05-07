namespace BackVentas.Modelos.ViewModel_DTO_
{
    public class VerPedidoViewModel
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public List<VerPedidoDetalleProductoViewModel> DetallesProductosPedido { get; set; }

        public VerPedidoViewModel()
        {
            this.DetallesProductosPedido = new List<VerPedidoDetalleProductoViewModel>();
        }
    }

    public class VerPedidoDetalleProductoViewModel
    {

        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }

    }
}
