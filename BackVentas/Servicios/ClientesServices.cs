using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;

namespace BackVentas.Servicios
{
    public class ClientesServices :IClientes
    {

        private readonly VentasContext _context;
        public ClientesServices(VentasContext context)
        {
            _context = context;
        }

        public List<ClienteViewModel> GetClientes()
        {
            var lista = _context.Clientes.Join(_context.Categorias,
                          cliente => cliente.IdCategoria,
                          categoria => categoria.Id,
                  (cliente, categoria) => new ClienteViewModel
                  {
                      Id = cliente.Id,
                      Nombre = cliente.Nombre,
                      Email = cliente.Email,
                      FechaCreacion = cliente.FechaCreacion,
                      Estado = cliente.Estado,
                      Identificacion = cliente.Identificacion,
                      NombreCategoria = categoria.Nombre,
                  }).ToList();

            return lista;
        }

        public crearClienteViewModel crearCliente(crearClienteViewModel cliente)
        {
            var validacion = _context.Clientes.FirstOrDefault(cli => cli.Identificacion == cliente.Identificacion);

            //validacion cliente existe
            if (validacion != null)
            {
                return null;
            }

            Cliente clienteCreado = new Cliente
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Email = cliente.Email,
                Contraseña = cliente.Contraseña,
                Estado = "SI",
                FechaCreacion = DateTime.Today,
                IdCategoria = cliente.IdCategoria,
                Identificacion = cliente.Identificacion,
            };

           

            _context.Clientes.Add(clienteCreado);
            _context.SaveChanges();

       
            return cliente;

        }

        public Cliente getCliente(int id)
        {

            var cliente = _context.Clientes.FirstOrDefault(x=> x.Id == id);

            return cliente;

        }

        public Cliente editarCliente(editarClienteViewModel cliente)
        {

            Cliente clienteEdit = _context.Clientes.Single(cli => cliente.Id == cli.Id );


            clienteEdit.Nombre = cliente.Nombre;
            clienteEdit.Email = cliente.Email;
            clienteEdit.IdCategoria = cliente.IdCategoria;
          



            _context.Clientes.Entry(clienteEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();


            return clienteEdit;
        }

        public string activarCliente(int id)
        {
            var cliente = _context.Clientes.Where(x => x.Id == id && x.Estado == "NO").FirstOrDefault();

            if (cliente == null)
            {
                return "El Cliente ya ha sido activado o no existe";
            }
            cliente.Estado = "SI";
            _context.SaveChanges();

            return "El Cliente activado exitosamente";
        }

        public string inactivarCliente(int id)
        {
            var cliente = _context.Clientes.Where(x => x.Id == id && x.Estado == "SI").FirstOrDefault();

            if (cliente == null)
            {
                return "El Cliente ya ha sido inactivado o no existe";
            }
            cliente.Estado = "NO";
            _context.SaveChanges();

            return "El Cliente inactivado exitosamente";
        }

        public string deleteCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            if (cliente == null)
            {
            return "Cliente no existe";

            }
            else
            {

            return "Cliente borrado existosamente";
            }


        }
    }

}
