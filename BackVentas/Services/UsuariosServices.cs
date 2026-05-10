using BackVentas.Models;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;

namespace BackVentas.Services
{
    public class UsuariosServices
    {
        private readonly VentasDbContext _context;

        public UsuariosServices(VentasDbContext context)
        {
            _context = context;
        }

        public ListaUsuarios GetListaUsuarios()
        {
            ListaUsuarios resultado = new ListaUsuarios();
            try
            {
                var lista =
                        (from usu in _context.Usuarios
                         join cat in _context.Categorias
                            on usu.Categoria equals cat.Id
                         select new UsuarioDTO
                         {
                             Id = usu.Id,
                             Login = usu.Login,
                             Nombres = usu.Nombres,
                             Apellidos = usu.Apellidos,
                             Estado = usu.Estado ? true : false,
                             CategoriaId = usu.Categoria,
                             NombreCategoria = cat.Nombre
                         }).ToList();

                resultado.Respuesta = "OK";
                resultado.Lista_Usuarios = lista;
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "ERROR";
            }

            return resultado;
        }

        public ResultadoUsuarioDTO GetUsuario(int ID)
        {
            ResultadoUsuarioDTO resultado = new ResultadoUsuarioDTO();
            try
            {
                var usuario =
                        (from usu in _context.Usuarios
                         join cat in _context.Categorias
                            on usu.Categoria equals cat.Id
                         where
                            usu.Id == ID
                         select new UsuarioDTO
                         {
                             Id = usu.Id,
                             Login = usu.Login,
                             Nombres = usu.Nombres,
                             Apellidos = usu.Apellidos,
                             Estado = usu.Estado ? true : false,
                             CategoriaId = usu.Categoria,
                             NombreCategoria = cat.Nombre
                         }).FirstOrDefault();

                if (usuario == null)
                {
                    resultado.Respuesta = "ERROR";
                    resultado.Mensaje = "Usuario no existe o está inactivo";
                    return resultado;
                }

                resultado.Respuesta = "OK";
                resultado.Usuario = usuario;
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "ERROR";
            }

            return resultado;
        }

        public Resultado CrearUsuario(crearUsuario Usu)
        {
            Resultado resultado = new Resultado();
            try
            {
                var usuExiste = (from USU in _context.Usuarios
                                 where USU.Login == Usu.Login
                                 select USU).FirstOrDefault();

                if (usuExiste != null)
                {
                    if (!usuExiste.Estado)
                    {
                        resultado.Respuesta = "ERROR";
                        resultado.Mensaje = "El usuario ya existe y esta inactivo";
                    }
                    else
                    {
                        resultado.Respuesta = "ERROR";
                        resultado.Mensaje = "El usuario ya existe";
                    }

                    return resultado;
                }

                Usuario newUsuario = new Usuario();
                newUsuario.Nombres = Usu.Nombres;
                newUsuario.Apellidos = Usu.Apellidos;
                newUsuario.Login = Usu.Login;
                newUsuario.Contrasena = Usu.Contrasena;
                newUsuario.Estado = true;
                newUsuario.Categoria = Usu.CategoriaId;

                _context.Usuarios.Add(newUsuario);
                _context.SaveChanges();

                resultado.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "ERROR";
            }

            return resultado;
        }

        public Resultado EditarUsuario(UsuarioDTO Usu)
        {
            Resultado resultado = new Resultado();
            try
            {
                var usuExiste = (from USU in _context.Usuarios
                                 where USU.Login == Usu.Login &&
                                        USU.Id == Usu.Id
                                 select USU).Count();

                if (usuExiste == 0)
                {
                    resultado.Respuesta = "ERROR";
                    resultado.Mensaje = "El usuario no existe";
                    return resultado;
                }

                var editUsu = (from USU in _context.Usuarios
                               where USU.Login == Usu.Login &&
                                      USU.Id == Usu.Id
                               select USU).FirstOrDefault();

                if (editUsu != null)
                {
                    editUsu.Nombres = Usu.Nombres;
                    editUsu.Apellidos = Usu.Apellidos;
                    editUsu.Categoria = Usu.CategoriaId;
                    editUsu.Estado = true;
                }

                _context.SaveChanges();
                resultado.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "ERROR";
            }

            return resultado;
        }

        public Resultado InactivarUsuario(string Login, int ID)
        {
            Resultado resultado = new Resultado();
            try
            {
                var usuExiste = (from USU in _context.Usuarios
                                 where USU.Login == Login &&
                                        USU.Id == ID
                                 select USU).FirstOrDefault();

                if (usuExiste == null)
                {
                    resultado.Respuesta = "ERROR";
                    resultado.Mensaje = "El usuario no existe";
                    return resultado;
                }
                else if (!usuExiste.Estado)
                {
                    resultado.Respuesta = "ERROR";
                    resultado.Mensaje = "El usuario ya se encuentra inactivo";
                    return resultado;
                }

                usuExiste.Estado = false;
                _context.SaveChanges();
                resultado.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "ERROR";
            }

            return resultado;
        }

        public Resultado ActivarUsuario(string Login, int ID)
        {
            Resultado resultado = new Resultado();
            try
            {
                var usuExiste = (from USU in _context.Usuarios
                                 where USU.Login == Login &&
                                        USU.Id == ID
                                 select USU).FirstOrDefault();

                if (usuExiste == null)
                {
                    resultado.Respuesta = "ERROR";
                    resultado.Mensaje = "El usuario no existe";
                    return resultado;
                }
                else if (usuExiste.Estado)
                {
                    resultado.Respuesta = "ERROR";
                    resultado.Mensaje = "El usuario ya se encuentra activo";
                    return resultado;
                }

                usuExiste.Estado = true;
                _context.SaveChanges();
                resultado.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "ERROR";
            }

            return resultado;
        }

        public ResultadoAsignacionCliente AsignarUsuarioCliente(int UsuarioID, int ClienteID)
        {
            ResultadoAsignacionCliente resultado = new ResultadoAsignacionCliente();
            try
            {
                csAsignacioCliente asignacionCliente = new csAsignacioCliente();
                asignacionCliente.UsuarioID = UsuarioID;
                asignacionCliente.ClienteID = ClienteID;

                var lAsignacion = (from ASI in _context.AsignacionClientes
                                   where UsuarioID == ASI.UsuarioId &&
                                         ClienteID == ASI.ClienteId
                                   select ASI).FirstOrDefault();

                if (lAsignacion != null)
                {
                    if (lAsignacion.Estado)
                    {
                        asignacionCliente.Resultado = "ERROR";
                        asignacionCliente.Mensaje = "La asignación al cliente " + ClienteID + " ya existe";
                    }
                    else
                    {
                        lAsignacion.Estado = true;
                    }

                    resultado.Asignacion_Cliente = asignacionCliente;
                    _context.SaveChanges();
                    return resultado;
                }

                BackVentas.Models.AsignacionCliente newAsignacion = new BackVentas.Models.AsignacionCliente();
                newAsignacion.UsuarioId = UsuarioID;
                newAsignacion.ClienteId = ClienteID;
                newAsignacion.Estado = true;

                asignacionCliente.Resultado = "OK";
                asignacionCliente.Mensaje = "Asignado correctamente";

                resultado.Asignacion_Cliente = asignacionCliente;
                _context.AsignacionClientes.Add(newAsignacion);
                resultado.Respuesta = "OK";
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Respuesta = "ERROR";
            }

            return resultado;
        }

        public ResultadoAsignacionCliente InactivarUsuarioCliente(int UsuarioID, int ClienteID)
        {
            ResultadoAsignacionCliente resultado = new ResultadoAsignacionCliente();
            try
            {
                csAsignacioCliente asignacionCliente = new csAsignacioCliente();
                asignacionCliente.UsuarioID = UsuarioID;
                asignacionCliente.ClienteID = ClienteID;

                var lAsignacion = (from ASI in _context.AsignacionClientes
                                   where UsuarioID == ASI.UsuarioId &&
                                         ClienteID == ASI.ClienteId
                                   select ASI).FirstOrDefault();

                if (lAsignacion == null)
                {
                    asignacionCliente.Resultado = "ERROR";
                    asignacionCliente.Mensaje = "La asignación al cliente " + ClienteID + "no existe";
                    resultado.Asignacion_Cliente = asignacionCliente;
                    return resultado;
                }

                lAsignacion.Estado = false;

                asignacionCliente.Resultado = "OK";
                asignacionCliente.Mensaje = "Asignado correctamente";
                resultado.Asignacion_Cliente = asignacionCliente;
                resultado.Respuesta = "OK";
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Respuesta = "ERROR";
            }

            return resultado;
        }

        public csListaCliente getClientesXUsuario(int UsuarioID)
        {
            csListaCliente resultado = new csListaCliente();
            try
            {
                var lClientes = (from ASI in _context.AsignacionClientes
                                 join CLI in _context.Clientes
                                     on ASI.ClienteId equals CLI.Id
                                 where ASI.Estado == true &&
                                       CLI.Estado == true &&
                                       ASI.UsuarioId == UsuarioID
                                 select CLI).ToList();

                if (!lClientes.Any())
                {
                    resultado.Respuesta = "OK";
                    return resultado;
                }

                foreach (Cliente lCliente in lClientes)
                {
                    ClienteDTO cliente = new ClienteDTO();
                    cliente.Id = lCliente.Id;
                    cliente.Nombre = lCliente.Nombre;
                    cliente.Nit = lCliente.Nit;
                    cliente.Direccion = lCliente.Direccion;
                    cliente.Estado = lCliente.Estado;

                    resultado.Lista_Clientes.Add(cliente);
                }

                resultado.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Respuesta = "ERROR";
            }

            return resultado;
        }

        public csListaCliente getClientesSINAsignarXUsuario(int UsuarioID)
        {
            csListaCliente resultado = new csListaCliente();
            try
            {
                var lClientes = (from CLI in _context.Clientes
                                 join ASI in _context.AsignacionClientes
                                     on new { Cliente_Id = CLI.Id, Usuario_Id = UsuarioID, Estado = true }
                                     equals new { Cliente_Id = ASI.ClienteId, Usuario_Id = ASI.UsuarioId, Estado = ASI.Estado }
                                     into ASI_LEFT
                                 from ASI in ASI_LEFT.DefaultIfEmpty()
                                 where ASI == null &&
                                       CLI.Estado == true
                                 select CLI).ToList();

                if (!lClientes.Any())
                {
                    resultado.Respuesta = "OK";
                    return resultado;
                }

                foreach (Cliente lCliente in lClientes)
                {
                    ClienteDTO cliente = new ClienteDTO();
                    cliente.Id = lCliente.Id;
                    cliente.Nombre = lCliente.Nombre;
                    cliente.Nit = lCliente.Nit;
                    cliente.Direccion = lCliente.Direccion;
                    cliente.Estado = lCliente.Estado;

                    resultado.Lista_Clientes.Add(cliente);
                }

                resultado.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Respuesta = "ERROR";
            }

            return resultado;
        }
    }
}
