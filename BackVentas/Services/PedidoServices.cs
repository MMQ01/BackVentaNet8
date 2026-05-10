using BackVentas.Models;
using BackVentasADO.Clases.DTO;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackVentas.Services
{
    public class PedidoServices
    {
        private readonly VentasDbContext _context;
        private readonly IHubContext<PedidosHub> _hubContext;

        public PedidoServices(VentasDbContext context, IHubContext<PedidosHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public csListaPedidos getListaPedidos()
        {
            csListaPedidos res = new csListaPedidos();
            try
            {
                List<PedidoDTO> lista = (from PED in _context.Pedidos
                                         join CLI in _context.Clientes
                                           on PED.IdCliente equals CLI.Id
                                         select new PedidoDTO
                                         {
                                             Id = PED.Id,
                                             ClienteID = PED.IdCliente,
                                             UsuarioID = PED.IdUsuario,
                                             fechaCreacion = PED.FechaCreacion,
                                             NombreCliente = CLI.Nombre,
                                             Origen = PED.Origen,
                                             total = PED.Total,
                                             detallesPedido = (from DET in _context.PedidoDetalles
                                                               join PRO in _context.Productos
                                                                on DET.IdProducto equals PRO.Id
                                                               where DET.IdPedido == PED.Id
                                                               select new DetallePedido
                                                               {
                                                                   Id = DET.Id,
                                                                   IdPedido = DET.IdPedido,
                                                                   IdProducto = DET.IdProducto,
                                                                   NombreProducto = PRO.Nombre,
                                                                   cantidad = DET.Cantidad,
                                                                   Precio = (decimal)PRO.Precio
                                                               }).ToList()
                                         }).OrderByDescending(x => x.fechaCreacion).ToList();

                res.Respuesta = "OK";
                res.Lista_Pedidos = lista;
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csListaPedidos getListaPedidosXCliente(int Id)
        {
            csListaPedidos res = new csListaPedidos();
            try
            {
                List<PedidoDTO> lista = (from PED in _context.Pedidos
                                         join CLI in _context.Clientes
                                            on PED.IdCliente equals CLI.Id
                                         where PED.Estado == true &&
                                                PED.IdCliente == Id
                                         select new PedidoDTO
                                         {
                                             Id = PED.Id,
                                             ClienteID = PED.IdCliente,
                                             UsuarioID = PED.IdUsuario,
                                             fechaCreacion = PED.FechaCreacion,
                                             Origen = PED.Origen,
                                             NombreCliente = CLI.Nombre,
                                             total = PED.Total,
                                             detallesPedido = (from DET in _context.PedidoDetalles
                                                               join PRO in _context.Productos
                                                                on DET.IdProducto equals PRO.Id
                                                               where DET.IdPedido == PED.Id
                                                               select new DetallePedido
                                                               {
                                                                   Id = DET.Id,
                                                                   IdPedido = DET.IdPedido,
                                                                   NombreProducto = PRO.Nombre,
                                                                   IdProducto = DET.IdProducto,
                                                                   cantidad = DET.Cantidad,
                                                                   Precio = (decimal)PRO.Precio
                                                               }).ToList()
                                         }).OrderByDescending(x => x.fechaCreacion).ToList();

                res.Respuesta = "OK";
                res.Lista_Pedidos = lista;
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csListaPedidos getListaPedidosXUsuario(int Id)
        {
            csListaPedidos res = new csListaPedidos();
            try
            {
                List<PedidoDTO> lista = (from PED in _context.Pedidos
                                         join CLI in _context.Clientes
                                           on PED.IdCliente equals CLI.Id
                                         where PED.Estado == true &&
                                                PED.IdUsuario == Id
                                         select new PedidoDTO
                                         {
                                             Id = PED.Id,
                                             ClienteID = PED.IdCliente,
                                             UsuarioID = PED.IdUsuario,
                                             fechaCreacion = PED.FechaCreacion,
                                             Origen = PED.Origen,
                                             total = PED.Total,
                                             NombreCliente = CLI.Nombre,
                                             detallesPedido = (from DET in _context.PedidoDetalles
                                                               join PRO in _context.Productos
                                                                on DET.IdProducto equals PRO.Id
                                                               where DET.IdPedido == PED.Id
                                                               select new DetallePedido
                                                               {
                                                                   Id = DET.Id,
                                                                   IdPedido = DET.IdPedido,
                                                                   NombreProducto = PRO.Nombre,
                                                                   IdProducto = DET.IdProducto,
                                                                   cantidad = DET.Cantidad,
                                                                   Precio = (decimal)PRO.Precio
                                                               }).ToList()
                                         }).OrderByDescending(x => x.fechaCreacion).ToList();

                res.Respuesta = "OK";
                res.Lista_Pedidos = lista;
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csPedido getPedido(int Id)
        {
            csPedido res = new csPedido();
            try
            {
                PedidoDTO pedido = (from PED in _context.Pedidos
                                    join CLI in _context.Clientes
                                      on PED.IdCliente equals CLI.Id
                                    where PED.Estado == true &&
                                           PED.Id == Id
                                    select new PedidoDTO
                                    {
                                        Id = PED.Id,
                                        ClienteID = PED.IdCliente,
                                        UsuarioID = PED.IdUsuario,
                                        fechaCreacion = PED.FechaCreacion,
                                        Origen = PED.Origen,
                                        total = PED.Total,
                                        NombreCliente = CLI.Nombre,
                                        detallesPedido = (from DET in _context.PedidoDetalles
                                                          join PRO in _context.Productos
                                                           on DET.IdProducto equals PRO.Id
                                                          where DET.IdPedido == PED.Id
                                                          select new DetallePedido
                                                          {
                                                              Id = DET.Id,
                                                              IdPedido = DET.IdPedido,
                                                              NombreProducto = PRO.Nombre,
                                                              IdProducto = DET.IdProducto,
                                                              cantidad = DET.Cantidad,
                                                              Precio = (decimal)PRO.Precio
                                                          }).OrderByDescending(x => x.cantidad).ToList()
                                    }).FirstOrDefault();

                res.Respuesta = "OK";
                res.Pedido = pedido;
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public Resultado guardarPedido(PedidoDTO pedido)
        {
            Resultado res = new Resultado();
            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                Pedido newPedido = new Pedido();
                newPedido.IdCliente = pedido.ClienteID;
                newPedido.Total = pedido.total;
                newPedido.FechaCreacion = DateTime.Now;
                newPedido.Estado = true;
                newPedido.Origen = pedido.Origen;
                newPedido.IdUsuario = pedido.UsuarioID;

                _context.Pedidos.Add(newPedido);
                _context.SaveChanges();

                foreach (var detalle in pedido.detallesPedido)
                {
                    PedidoDetalle newDetalle = new PedidoDetalle();
                    newDetalle.Cantidad = detalle.cantidad;
                    newDetalle.IdProducto = detalle.IdProducto;
                    newDetalle.IdPedido = newPedido.Id;
                    _context.PedidoDetalles.Add(newDetalle);
                }

                _context.SaveChanges();
                transaccion.Commit();

                var nombreCliente = _context.Clientes
                    .Where(x => x.Id == newPedido.IdCliente)
                    .Select(x => x.Nombre)
                    .FirstOrDefault();

                _hubContext.Clients.All.SendAsync("ReceiveAllOrders", new PedidoDTO
                {
                    Id = newPedido.Id,
                    ClienteID = newPedido.IdCliente,
                    total = newPedido.Total,
                    fechaCreacion = newPedido.FechaCreacion,
                    detallesPedido = null,
                    NombreCliente = nombreCliente,
                    Origen = newPedido.Origen,
                    UsuarioID = newPedido.IdUsuario
                });

                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public Resultado activarPedido(int id)
        {
            Resultado res = new Resultado();
            try
            {
                var pedido = (from PED in _context.Pedidos
                              where PED.Id == id
                              select PED).FirstOrDefault();

                if (pedido == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El pedido no existe";
                    return res;
                }
                else if (pedido.Estado == true)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El pedido ya se encuentra activo";
                    return res;
                }

                pedido.Estado = true;
                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public Resultado inactivarPedido(int id)
        {
            Resultado res = new Resultado();
            try
            {
                var pedido = (from PED in _context.Pedidos
                              where PED.Id == id
                              select PED).FirstOrDefault();

                if (pedido == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El pedido no existe";
                    return res;
                }
                else if (pedido.Estado == false)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El pedido ya se encuentra inactivo";
                    return res;
                }

                pedido.Estado = false;
                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csCarrito getListaProductosCarrito(int usuarioID)
        {
            csCarrito res = new csCarrito();
            try
            {
                var lCarrito = (from CAR in _context.TmpCarritos
                                join PRO in _context.Productos
                                    on CAR.ProductoId equals PRO.Id
                                join USU in _context.Usuarios
                                  on CAR.UsuarioId equals USU.Id
                                where CAR.UsuarioId == usuarioID &&
                                     PRO.Estado == true &&
                                     USU.Estado == true
                                select new { PRO, CAR, USU }).ToList();

                if (lCarrito.Count == 0)
                {
                    res.Respuesta = "OK";
                    res.Mensaje = "El Usuario no tiene productos en el carrito";
                    return res;
                }

                foreach (var lProducto in lCarrito)
                {
                    CarritoDTO carritoDTO = new CarritoDTO();
                    carritoDTO.ID = lProducto.CAR.Id;
                    carritoDTO.Usuario_ID = lProducto.CAR.UsuarioId;
                    carritoDTO.Nombre_Usuario = lProducto.USU.Nombres;
                    carritoDTO.Producto_ID = lProducto.CAR.ProductoId;
                    carritoDTO.Nombre_Producto = lProducto.PRO.Nombre;
                    carritoDTO.Precio = (double)lProducto.PRO.Precio;
                    carritoDTO.SKU = lProducto.PRO.SKU;
                    carritoDTO.Cantidad = lProducto.CAR.Cantidad;

                    res.Lista_Productos.Add(carritoDTO);
                }

                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public Resultado eliminarCarrito(int usuarioID)
        {
            Resultado res = new Resultado();
            try
            {
                var lCarrito = (from CAR in _context.TmpCarritos
                                where CAR.UsuarioId == usuarioID
                                select CAR).ToList();

                if (lCarrito.Count == 0)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El Usuario no tiene productos en el carrito";
                    return res;
                }

                _context.TmpCarritos.RemoveRange(lCarrito);
                _context.SaveChanges();

                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public Resultado eliminarProductoCarrito(int usuarioID, int productoID)
        {
            Resultado res = new Resultado();
            try
            {
                var lCarrito = (from CAR in _context.TmpCarritos
                                where CAR.UsuarioId == usuarioID &&
                                      CAR.ProductoId == productoID
                                select CAR).FirstOrDefault();

                if (lCarrito == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El Usuario no tiene productos en el carrito";
                    return res;
                }

                _context.TmpCarritos.Remove(lCarrito);
                _context.SaveChanges();

                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public Resultado actualizarProductoCarrito(int usuarioID, int productoID, double Cantidad = 1)
        {
            Resultado res = new Resultado();
            try
            {
                var lProducto = (from PRO in _context.Productos
                                 where PRO.Id == productoID &&
                                       PRO.Estado == true
                                 select PRO).FirstOrDefault();

                if (lProducto == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto no está disponible";
                    return res;
                }

                var lCarrito = (from CAR in _context.TmpCarritos
                                where CAR.UsuarioId == usuarioID &&
                                      CAR.ProductoId == productoID
                                select CAR).FirstOrDefault();

                if (lCarrito == null)
                {
                    TmpCarrito tmp_Carrito = new TmpCarrito();
                    tmp_Carrito.UsuarioId = usuarioID;
                    tmp_Carrito.ProductoId = productoID;
                    tmp_Carrito.Cantidad = Cantidad;

                    _context.TmpCarritos.Add(tmp_Carrito);
                }
                else if (lCarrito.Cantidad == Cantidad)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto ya está registrado en el carrito.";
                    return res;
                }
                else if (lCarrito.Cantidad <= 0)
                {
                    eliminarProductoCarrito(usuarioID, productoID);
                    res.Respuesta = "OK";
                    return res;
                }
                else
                {
                    lCarrito.Cantidad = Cantidad;
                }

                _context.SaveChanges();
                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }
    }
}