using BackVentas.Models;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Authorization;
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
        private readonly VentasDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(VentasDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public ResultadoToken Login([FromBody] LoginViewModel login)
        {
            var resultado = new ResultadoToken();
            try
            {
                var usuario = (from USU in _context.Usuarios
                               where USU.Login == login.Login &&
                                      USU.Contrasena == login.Password
                               select USU).FirstOrDefault();

                if (usuario == null)
                {
                    resultado.Mensaje = "Usuario no existe";
                    resultado.Respuesta = "ERROR";
                    return resultado;
                }

                if (!usuario.Estado)
                {
                    resultado.Mensaje = "Usuario Inactivo";
                    resultado.Respuesta = "ERROR";
                    return resultado;
                }

                var token = GenerarTokenJWT(usuario);

                var usuarioData = new UsuarioDTO
                {
                    Id = usuario.Id,
                    Login = usuario.Login,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Estado = usuario.Estado,
                    CategoriaId = usuario.Categoria,
                };

                var nombreCategoria = _context.Categorias
                    .FirstOrDefault(x => x.Id == usuario.Categoria)?.Nombre;

                usuarioData.NombreCategoria = string.IsNullOrEmpty(nombreCategoria) ? "Sin categoria" : nombreCategoria;

                resultado.Respuesta = "OK";
                resultado.Usuario = usuarioData;
                resultado.Token = token;
            }
            catch (Exception ex)
            {
                resultado.Respuesta = "ERROR";
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }

        private string GenerarTokenJWT(Usuario usuarioInfo)
        {
            var claveJWT = _configuration["JWT:ClaveJWT"];
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveJWT));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, usuarioInfo.Login),
                new Claim("Id", usuarioInfo.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

