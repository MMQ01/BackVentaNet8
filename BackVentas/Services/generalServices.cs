using BackVentas.Models;
using BackVentasADO.Clases.DTO;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackVentas.Services
{
    public class generalServices
    {
        private readonly VentasDbContext _context;
        private readonly IConfiguration _configuration;

        public generalServices(VentasDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public csEstadisticaEnc getEstadisticasEnc()
        {
            var res = new csEstadisticaEnc();
            try
            {
                var connectionString = _context.Database.GetConnectionString();

                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SPU_ESTADISTICA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var pVentas = new SqlParameter("@oVentas", SqlDbType.Decimal) { Precision = 18, Scale = 2, Direction = ParameterDirection.Output };
                    var pPedidos = new SqlParameter("@oPedidos", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pClientes = new SqlParameter("@oClientes", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pProductos = new SqlParameter("@oProductos", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pVentas);
                    cmd.Parameters.Add(pPedidos);
                    cmd.Parameters.Add(pClientes);
                    cmd.Parameters.Add(pProductos);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    res.ventaTotales = Convert.ToDouble(pVentas.Value);
                    res.pedidoTotales = Convert.ToInt32(pPedidos.Value);
                    res.clientesTotales = Convert.ToInt32(pClientes.Value);
                    res.productosTotales = Convert.ToInt32(pProductos.Value);
                    res.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csUltimasVentas getUltimasVentas()
        {
            var res = new csUltimasVentas { Detalle = new List<csUltimasVentasDetalle>() };
            try
            {
                var connectionString = _context.Database.GetConnectionString();

                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SPU_ULTIMAS_VENTAS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res.Detalle.Add(new csUltimasVentasDetalle
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NombreCliente = reader.GetString(reader.GetOrdinal("NombreCliente")),
                                NombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario")),
                                Origen = reader.GetString(reader.GetOrdinal("Origen")),
                                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                            });
                        }
                    }

                    res.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csTopUsuarios getTopUsuarios()
        {
            var res = new csTopUsuarios { Detalle = new List<csTopUsuarioDetalle>() };
            try
            {
                var connectionString = _context.Database.GetConnectionString();

                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SPU_TOP_USUARIO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res.Detalle.Add(new csTopUsuarioDetalle
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                NombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario")),
                                CantidadPedidos = reader.GetInt32(reader.GetOrdinal("CantidadPedidos")),
                            });
                        }
                    }

                    res.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }

        public csReportesStock getReporteStock()
        {
            var res = new csReportesStock { Detalle = new List<csReporteStockDetalle>() };
            try
            {
                var connectionString = _context.Database.GetConnectionString();

                using (var con = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SPU_STOCK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res.Detalle.Add(new csReporteStockDetalle
                            {
                                IdProducto = reader.GetInt32(reader.GetOrdinal("Id")),
                                NombreProducto = reader.GetString(reader.GetOrdinal("Nombre")),
                                Stock = Convert.ToDouble(reader["Stock"]),
                                Msg = reader.GetString(reader.GetOrdinal("Msg")),
                            });
                        }
                    }

                    res.Respuesta = "OK";
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
