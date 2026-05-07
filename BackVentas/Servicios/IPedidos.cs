using BackVentas.Modelos.ViewModel_DTO_;

namespace BackVentas.Servicios
{
    public interface IPedidos
    {

        public CrearPedidoViewModel guardarPedido(CrearPedidoViewModel prod);

        public List<VerPedidoViewModel> verPedidosXCliente(int identificacion);

        public string inactivarPedido(int id);
        public string activarPedido(int id);
        public string borrarPedido(int id);
        public List<VerPedidoViewModel> verPedidos();

    }
}
