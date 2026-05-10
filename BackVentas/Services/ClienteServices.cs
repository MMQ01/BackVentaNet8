using BackVentas.Models;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.EntityFrameworkCore;

namespace BackVentasADO.Controllers.Services
{
    public class ClienteServices
    {

        private readonly VentasDbContext _context;
        public ClienteServices(VentasDbContext context)
        {
            _context = context;
        }

        public csListaCliente GetClientes()
        {

            csListaCliente res = new csListaCliente();
            try
            {

                var lista = (from CLI in _context.Clientes
                             select new ClienteDTO
                             {
                                 Id = CLI.Id,
                                 Nombre = CLI.Nombre,
                                 Direccion = CLI.Direccion,
                                 Estado = CLI.Estado ? true : false,
                                 Nit = CLI.Nit

                             }).ToList();

                res.Respuesta = "OK";
                res.Lista_Clientes = lista;

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }


        public csListaCliente GetClientesXUsuario(int Usuario)
        {

            csListaCliente res = new csListaCliente();
            try
            {


                var lista = (from CLI in _context.Clientes
                             join ASI in _context.AsignacionClientes
                                on CLI.Id equals ASI.ClienteId
                             where CLI.Estado == true &&
                                    ASI.UsuarioId == Usuario
                             select new ClienteDTO
                             {
                                 Id = CLI.Id,
                                 Nombre = CLI.Nombre,
                                 Direccion = CLI.Direccion,
                                 Estado = CLI.Estado ? true : false,
                                 Nit = CLI.Nit

                             }).ToList();

                res.Respuesta = "OK";
                res.Lista_Clientes = lista;

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        public Resultado crearCliente(ClienteDTO cliente)
        {

            Resultado res = new Resultado();
            try
            {

                var validacion = (from CLI in _context.Clientes
                                  where CLI.Estado == true
                                  select CLI).FirstOrDefault();

                //validacion cliente existe
                if (validacion != null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El cliente ya existe";
                }

                Cliente clienteCreado = new Cliente
                {

                    Nombre = cliente.Nombre,
                    Direccion = cliente.Direccion,
                    Nit = cliente.Nit,
                    Estado = true,
                };



                _context.Clientes.Add(clienteCreado);
                _context.SaveChanges();

                res.Respuesta = "OK";

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;

        }

        public csCliente getCliente(int id)
        {
            csCliente res = new csCliente();

            try
            {


                var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

                var clienteDto = new ClienteDTO
                {
                    Id = cliente.Id,
                    Nit = cliente.Nit,
                    Nombre = cliente.Nombre,
                    Estado = cliente.Estado,
                    Direccion = cliente.Direccion

                };

                res.Cliente = clienteDto;
                res.Respuesta = "OK";

                return res;

            }
            catch (Exception ex)
            {


                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }

        }

        public Resultado editarCliente(ClienteDTO cliente)
        {

            Resultado res = new Resultado();

            try
            {
                Cliente clienteEdit = (from CLI in _context.Clientes
                                        where
                                         CLI.Id == cliente.Id &&
                                         CLI.Nit == cliente.Nit
                                        select CLI).FirstOrDefault();




                clienteEdit.Nombre = cliente.Nombre;
                clienteEdit.Direccion = cliente.Direccion;

                _context.SaveChanges();

                res.Respuesta = "OK";

            }
            catch (Exception ex)
            {


                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        public Resultado activarCliente(int id)
        {

            Resultado res = new Resultado();

            try
            {

                var cliente = _context.Clientes.Where(x => x.Id == id).FirstOrDefault();

                if (cliente == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El cliente no existe";
                    return res;
                }

                if (cliente?.Estado == true)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El cliente ya se encuentra activo";
                    return res;
                }


                cliente.Estado = true;
                _context.SaveChanges();

                res.Respuesta = "OK";

                return res;

            }
            catch (Exception ex)
            {


                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }

        }

        public Resultado inactivarCliente(int id)
        {
            Resultado res = new Resultado();

            try
            {

                var cliente = _context.Clientes.Where(x => x.Id == id).FirstOrDefault();

                if (cliente == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El cliente no existe";
                    return res;
                }

                if (cliente?.Estado == false)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El cliente ya se encuentra inactivo";
                    return res;
                }



                cliente.Estado = false;
                _context.SaveChanges();

                res.Respuesta = "OK";

                return res;

            }
            catch (Exception ex)
            {


                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }

        public string getNombreCliente(int clienteID)
        {
            string NombreCliente = "";

            try
            {
                NombreCliente = (from CLI in _context.Clientes
                                 where CLI.Id == clienteID
                                 select CLI.Nombre).FirstOrDefault() ?? "";
            }
            catch (Exception ex)
            {
                return "";
            }

            return NombreCliente;
        }

        public ResultadoBoolean checkNIT(string nit)
        {

            ResultadoBoolean res = new ResultadoBoolean();
            try
            {

                var validacion = (from CLI in _context.Clientes
                                  where CLI.Nit == nit
                                  select CLI).FirstOrDefault();

                //validacion cliente existe
                if (validacion != null)
                {
                    res.Respuesta = "OK";
                    res.Valor = true;
                    return res;
                }


                res.Valor = false;
                res.Respuesta = "OK";

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Valor = false;
                return res;
            }
            return res;

        }

    }
}