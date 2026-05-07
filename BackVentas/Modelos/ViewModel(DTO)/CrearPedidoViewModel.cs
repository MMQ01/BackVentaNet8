namespace BackVentas.Modelos.ViewModel_DTO_
{
    public class CrearPedidoViewModel
    {

        public int IdCliente { get; set; }

        public decimal Total { get; set; }

        public DateTime FechaCreacion { get; set; }

        public List<CrearDetallePedidoViewModel> DetallesPedido { get; set; }


        public CrearPedidoViewModel()
        {
            this.DetallesPedido = new List<CrearDetallePedidoViewModel>();
        }

    }

    public class CrearDetallePedidoViewModel
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

}
