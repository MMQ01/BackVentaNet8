using BackVentas.Services;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuariosServices _usuariosServices;

        public UsuarioController(UsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }

        [HttpGet]
        [Route("api/Usuarios")]
        public ListaUsuarios GetUsuarios()
        {
            ListaUsuarios res = new ListaUsuarios();
            try
            {
                var lista = _usuariosServices.GetListaUsuarios();
                if (lista.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Lista_Usuarios = lista.Lista_Usuarios;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpGet]
        [Route("api/Usuario")]
        public ResultadoUsuarioDTO GetUsuario(int identificacion)
        {
            ResultadoUsuarioDTO res = new ResultadoUsuarioDTO();
            try
            {
                var usuario = _usuariosServices.GetUsuario(identificacion);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Usuario = usuario.Usuario;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpPost]
        [Route("api/Usuario")]
        public Resultado CrearUsuario([FromBody] crearUsuario CreateUsuario)
        {
            Resultado res = new Resultado();
            try
            {
                var usuario = _usuariosServices.CrearUsuario(CreateUsuario);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Mensaje = usuario.Mensaje;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpPut]
        [Route("api/Usuario")]
        public Resultado EditarUsuario([FromBody] UsuarioDTO editUsuario)
        {
            Resultado res = new Resultado();
            try
            {
                var usuario = _usuariosServices.EditarUsuario(editUsuario);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Mensaje = usuario.Mensaje;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpPost]
        [Route("api/InactivarUsuarios")]
        public Resultado InactivarUsuario([FromBody] userSelected usuarioReq)
        {
            Resultado res = new Resultado();
            try
            {
                var usuario = _usuariosServices.InactivarUsuario(usuarioReq.Login, usuarioReq.ID);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Mensaje = usuario.Mensaje;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpPost]
        [Route("api/ActivarUsuarios")]
        public Resultado ActivarUsuario([FromBody] userSelected usuarioReq)
        {
            Resultado res = new Resultado();
            try
            {
                var usuario = _usuariosServices.ActivarUsuario(usuarioReq.Login, usuarioReq.ID);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Mensaje = usuario.Mensaje;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpPost]
        [Route("api/AsignarUsuariosAClientes")]
        public Resultado AsignarUsuarioCliente([FromBody] AsignacionCliente request)
        {
            Resultado res = new Resultado();
            try
            {
                var usuario = _usuariosServices.AsignarUsuarioCliente(request.UsuarioID, request.ClienteID);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Mensaje = usuario.Mensaje;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpPost]
        [Route("api/InactivarAsignacionUsuariosAClientes")]
        public Resultado InactivarAsignacionUsuariosAClientes([FromBody] AsignacionCliente request)
        {
            Resultado res = new Resultado();
            try
            {
                var usuario = _usuariosServices.InactivarUsuarioCliente(request.UsuarioID, request.ClienteID);
                if (usuario.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Mensaje = usuario.Mensaje;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuario.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpGet]
        [Route("api/ClientesAsignados")]
        public csListaCliente GetClientesAsignadoXUsuario(int usuarioID)
        {
            csListaCliente res = new csListaCliente();
            try
            {
                var clientes = _usuariosServices.getClientesXUsuario(usuarioID);
                if (clientes.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Lista_Clientes = clientes.Lista_Clientes;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = clientes.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        [HttpGet]
        [Route("api/ClientesSINAsignar")]
        public csListaCliente GetClientesSINAsignarXUsuario(int usuarioID)
        {
            csListaCliente res = new csListaCliente();
            try
            {
                var clientes = _usuariosServices.getClientesSINAsignarXUsuario(usuarioID);
                if (clientes.Respuesta == "OK")
                {
                    res.Respuesta = "OK";
                    res.Lista_Clientes = clientes.Lista_Clientes;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = clientes.Mensaje;
                }
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
