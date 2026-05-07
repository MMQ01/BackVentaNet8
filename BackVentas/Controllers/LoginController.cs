using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        VentasContext _context;
        IConfiguration _configuration;

        public LoginController(VentasContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
                ResultadoToken resultado = new ResultadoToken();
            try
            {

                var cliente = _context.Clientes.FirstOrDefault(x => x.Identificacion == login.Identificacion);

               
                if (cliente == null)
                {
                    resultado.Respuesta = "Cliente no existe";
                    resultado.Mensaje = "Error";
                    return Ok(resultado);
                }
                if (cliente.Estado != "SI")
                {
                    resultado.Respuesta = "Cliente Inactivo";
                    resultado.Mensaje = "Error";
                    return Ok(resultado);
                }
                if (cliente.Contraseña != login.contraseña)
                {
                    resultado.Respuesta = "Error en la contraseña";
                    resultado.Mensaje = "Error";
                    return Ok(resultado);
                }

                var token = GenerarTokenJWT(cliente);
                Console.WriteLine(token);
                resultado.Respuesta = cliente;
                resultado.Mensaje = "OK";
                resultado.token = token;
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                resultado.Respuesta = ex.Message;
                resultado.Mensaje = "Error";
                return BadRequest(resultado);
            }

           
        }


        private string GenerarTokenJWT(Cliente usuarioInfo)
        {
            try
            {
                // Cabecera
                var _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:ClaveJWT"]));

                var _signingCredentials = new SigningCredentials(
                        _symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var _Header = new JwtHeader(_signingCredentials);
                // Claims
                var _Claims = new[] {
                       new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                  };

                //Payload
                var _Payload = new JwtPayload(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: _Claims,
                        notBefore: DateTime.UtcNow,
                        expires: DateTime.UtcNow.AddHours(24));

                //Token
                var _Token = new JwtSecurityToken(_Header, _Payload);
                string token = new JwtSecurityTokenHandler().WriteToken(_Token);

                return token;
            }
            catch (Exception ex)
            {
                // Manejar la excepción y registrar el error
                Console.WriteLine(ex);
                throw new InvalidOperationException("Error al generar el token JWT.", ex);
            }
        }
    }
}
