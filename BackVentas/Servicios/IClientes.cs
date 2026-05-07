using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;

namespace BackVentas.Servicios
{
    public interface IClientes
    {

        public List<ClienteViewModel> GetClientes();

        public crearClienteViewModel crearCliente(crearClienteViewModel cliente);

        public Cliente getCliente(int id);

        public Cliente editarCliente(editarClienteViewModel cliente);
        public string activarCliente(int id);
        public string inactivarCliente(int id);
        public string deleteCliente(int id);

    }
}
