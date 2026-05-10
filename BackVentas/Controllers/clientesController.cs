using BackVentasADO.Controllers.Services;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly ClienteServices _clientesService;

        public ClientesController(ClienteServices clientesService)
        {
            _clientesService = clientesService;
        }




        [HttpGet]
        [Route("api/Clientes")]
        public csListaCliente getClientes()
        {
            csListaCliente res = new csListaCliente();
            try
            {

                var lista = _clientesService.GetClientes();

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Lista_Clientes = lista.Lista_Clientes;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {

                res.Respuesta = "Error";
                return res;
            }
            return res;
        }

        [HttpGet("PorUsuario")]
        public csListaCliente getClientesXUsuario(int Usuario)
        {
            csListaCliente res = new csListaCliente();
            try
            {

                var lista = _clientesService.GetClientesXUsuario(Usuario);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Lista_Clientes = lista.Lista_Clientes;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {

                res.Respuesta = "Error";
                return res;
            }
            return res;
        }


        [HttpPost]
        [Route("api/Clientes")]
        public Resultado crearCliente([FromBody] ClienteDTO cli)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = _clientesService.crearCliente(cli);


                if (cliente.Respuesta == "OK")
                {

                    res.Respuesta = "OK";


                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = cliente.Mensaje;
                }
            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }

            return res;
        }


        [HttpGet("api/Cliente")]
        public csCliente getCliente(int clienteID)
        {
            csCliente res = new csCliente();
            try
            {

                var cliente = _clientesService.getCliente(clienteID);

                if (cliente.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Cliente = cliente.Cliente;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = cliente.Mensaje;
                }
            }
            catch (Exception ex)
            {


                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }

            return res;
        }

        [HttpPut]
        [Route("api/Clientes")]
        public Resultado editarCliente(ClienteDTO cli)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = _clientesService.editarCliente(cli);
                if (cliente.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = cliente.Mensaje;
                }
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return res;
            }

            return res;
        }

        [HttpPost]
        [Route("api/Clientes/InactivarCliente")]
        public Resultado inactivarCliente([FromBody] int id)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = _clientesService.inactivarCliente(id);

                if (cliente.Respuesta == "OK")
                {

                    res.Respuesta = cliente.Respuesta;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = cliente.Mensaje;
                }
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return res;
            }

            return res;

        }

        [HttpPost]
        [Route("api/Clientes/ActivarCliente")]
        public Resultado activarCliente([FromBody] int id)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = _clientesService.activarCliente(id);

                if (cliente.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = cliente.Mensaje;
                }
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return res;
            }

            return res;

        }

        [HttpGet]
        [Route("api/Clientes/CheckNIT")]
        public ResultadoBoolean checNIT(string nit)
        {
            ResultadoBoolean res = new ResultadoBoolean();
            try
            {

                var cliente = _clientesService.checkNIT(nit);

                if (cliente.Respuesta == "OK")
                {

                    res.Respuesta = cliente.Respuesta;
                    res.Valor = cliente.Valor;
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Valor = false;
                }

            }
            catch (Exception)
            {

                res.Valor = false;
                res.Respuesta = "ERROR";
                return res;
            }

            return res;

        }

    }
}
