using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackVentas.Servicios
{
    public class PedidoServices:IPedidos
    {

        VentasContext _context;
        public PedidoServices(VentasContext context)
        {
            _context = context;
        }


        public CrearPedidoViewModel guardarPedido(CrearPedidoViewModel p)
        {
            IDbContextTransaction transaccion = null;
            try
            {

                transaccion = _context.Database.BeginTransaction();
                {

                    var pedido = new Pedido();
                    pedido.Total = p.Total;
                    pedido.IdCliente = p.IdCliente;
                    pedido.FechaCreacion = DateTime.Now;
                    pedido.Estado = "SI";

                    _context.Pedidos.Add(pedido);
                    _context.SaveChanges();

                    foreach (var d in p.DetallesPedido)
                    {
                        var detalle = new ProductosPedido();
                        detalle.Cantidad = d.Cantidad;
                        detalle.IdProducto = d.IdProducto;
                        detalle.IdPedido = pedido.Id;
                        _context.ProductosPedidos.Add(detalle);
                        _context.SaveChanges();
                    }

                    transaccion.Commit();
                 
                }

            }
            catch (Exception)
            {

                if (transaccion != null)
                { transaccion.Rollback(); }
            }

            return p;
        }

        public List<VerPedidoViewModel> verPedidosXCliente(int Identificacion)
        {
            List<VerPedidoViewModel> lista = new List<VerPedidoViewModel>();

           
            var cliente = _context.Clientes.FirstOrDefault(cli=> cli.Identificacion == Identificacion);

            if(cliente == null)
            {
                return lista;
            }

   
            List<Pedido> listaPedidos = (from p in _context.Pedidos where
                                         p.IdCliente == cliente.Id && p.Estado == "SI" select p).ToList();

            foreach (Pedido pedido in listaPedidos)
            {
                VerPedidoViewModel auxPedido = new VerPedidoViewModel();

                auxPedido.Total = pedido.Total;
                auxPedido.Cliente = cliente.Nombre;
                auxPedido.Id = pedido.Id;
                List<ProductosPedido> listaDetalle= (from pd in _context.ProductosPedidos where
                                                     pd.IdPedido == pedido.Id select pd).ToList();

                foreach (ProductosPedido productoPedido in listaDetalle)
                {
                    VerPedidoDetalleProductoViewModel prod = new VerPedidoDetalleProductoViewModel();
                    prod.Cantidad = productoPedido.Cantidad;

                    var prodAux = _context.Productos.FirstOrDefault(p => p.Id == productoPedido.IdProducto);

                    prod.NombreProducto = prodAux.Nombre;

                    auxPedido.DetallesProductosPedido.Add(prod);
                }

                lista.Add(auxPedido);

            }

            return lista;
        }

        public string activarPedido(int id)
        {
            var pedido = _context.Pedidos.Where(x => x.Id == id && x.Estado == "NO").FirstOrDefault();

            if (pedido == null)
            {
                return "El pedido ya ha sido activado o no existe";
            }
            pedido.Estado = "SI";
            _context.SaveChanges();

            return "El pedido activado exitosamente";
        }

        public string inactivarPedido(int id)
        {
            var pedido = _context.Pedidos.Where(x => x.Id == id && x.Estado == "SI").FirstOrDefault();

            if (pedido == null)
            {
                return "El pedido ya ha sido inactivado o no existe";
            }
            pedido.Estado = "NO";
            _context.SaveChanges();

            return "El pedido inactivado exitosamente";
        }

        public string borrarPedido(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(x => x.Id == id);
        

            if (pedido == null)
            {
                return "Producto ya ha sido eliminado o no existe";
            }
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return "Producto eliminado exitosamente";

        }

        public List<VerPedidoViewModel> verPedidos()
        {
        List<VerPedidoViewModel> lista = new List<VerPedidoViewModel>();

           
            var cliente = _context.Clientes.ToList();

           

   
            List<Pedido> listaPedidos =_context.Pedidos.ToList();

            foreach (Pedido pedido in listaPedidos)
            {
                VerPedidoViewModel auxPedido = new VerPedidoViewModel();

                auxPedido.Total = pedido.Total;
                auxPedido.Cliente = cliente.Find(c=> c.Id == pedido.IdCliente).Nombre;
                auxPedido.Id = pedido.Id;
                auxPedido.Estado = pedido.Estado;
                List<ProductosPedido> listaDetalle= (from pd in _context.ProductosPedidos where
                                                     pd.IdPedido == pedido.Id select pd).ToList();

                foreach (ProductosPedido productoPedido in listaDetalle)
                {
                    VerPedidoDetalleProductoViewModel prod = new VerPedidoDetalleProductoViewModel();
                    prod.Cantidad = productoPedido.Cantidad;

                    var prodAux = _context.Productos.FirstOrDefault(p => p.Id == productoPedido.IdProducto);

                    prod.NombreProducto = prodAux.Nombre;

                    auxPedido.DetallesProductosPedido.Add(prod);
                }

                lista.Add(auxPedido);

            }

            return lista;
        }
    }
}
