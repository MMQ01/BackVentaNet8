using BackVentas.Services;
using BackVentasADO.Clases.DTO;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{

    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly generalServices _generalServices;

        public GeneralController(generalServices generalServices)
        {
            _generalServices = generalServices;
        }


        // GET: General
        [HttpGet]
        [Route("api/Estadisticas/Encabezados")]
        public csEstadisticaEnc getEstadisticas()
        {
            csEstadisticaEnc res = new csEstadisticaEnc();
            try
            {

                csEstadisticaEnc estadistica = _generalServices.getEstadisticasEnc();

                if (estadistica.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.clientesTotales = estadistica.clientesTotales;
                    res.pedidoTotales = estadistica.pedidoTotales;
                    res.ventaTotales = estadistica.ventaTotales;
                    res.productosTotales = estadistica.productosTotales;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = estadistica.Mensaje;
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


        // ── Últimas ventas ────────────────────────────────────────────────
        [HttpGet]
        [Route("api/Estadisticas/UltimasVentas")]
        public csUltimasVentas getUltimasVentas()
        {
            csUltimasVentas res = new csUltimasVentas();
            try
            {
                csUltimasVentas ventas = _generalServices.getUltimasVentas();
                if (ventas.Respuesta == "OK")
                {
                    res.Detalle = ventas.Detalle;
                    res.Respuesta = "OK";
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = ventas.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }


        // ── Top usuarios ──────────────────────────────────────────────────
        [HttpGet]
        [Route("api/Estadisticas/TopUsuarios")]
        public csTopUsuarios getTopUsuarios()
        {
            csTopUsuarios res = new csTopUsuarios();
            try
            {
                csTopUsuarios usuarios = _generalServices.getTopUsuarios();
                if (usuarios.Respuesta == "OK")
                {
                    res.Detalle = usuarios.Detalle;
                    res.Respuesta = "OK";
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = usuarios.Mensaje;
                }
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
            }
            return res;
        }


        // ── Reporte stock ─────────────────────────────────────────────────
        [HttpGet]
        [Route("api/Estadisticas/ReporteStock")]
        public csReportesStock getReporteStock()
        {
            csReportesStock res = new csReportesStock();
            try
            {
                csReportesStock stock = _generalServices.getReporteStock();
                if (stock.Respuesta == "OK")
                {
                    res.Detalle = stock.Detalle;
                    res.Respuesta = "OK";
                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = stock.Mensaje;
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
