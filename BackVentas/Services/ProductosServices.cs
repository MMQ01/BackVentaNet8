using BackVentas.Models;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackVentas.Services
{
    public class ProductosServices
    {

        private readonly VentasDbContext _context;
        private readonly IConfiguration _configuration;

        public ProductosServices(VentasDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public csListaProducto getProductos(bool? pEstado, int? UsuarioID)
        {

            csListaProducto res = new csListaProducto();

            try
            {

         

                List<ProductoDTO> lista;

                if (pEstado == null)
                {
                    lista = (from PRO in _context.Productos
                             select new ProductoDTO
                             {
                                 Id = PRO.Id,
                                 Nombre = PRO.Nombre,
                                 Descripcion = PRO.Descripcion,
                                 Estado = (bool)PRO.Estado ? true : false,
                                 Precio = (decimal)PRO.Precio,
                                 Stock = (decimal)PRO.Stock,
                                 SKU = PRO.SKU
                             }).Take(200).ToList();
                }
                else
                {
                    if (UsuarioID == null)
                    {
                        res.Respuesta = "ERROR";
                        res.Mensaje = "Error al consultar el usuario ID";
                        return res;
                    }


                    lista = (from PRO in _context.Productos
                             join FAV in _context.ProductosFavoritos
                                on new { ProductoID = PRO.Id, UsuarioID = (int)UsuarioID }
                                equals new { ProductoID = FAV.ProductoId, UsuarioID = FAV.UsuarioId }
                               into favJoin
                             from FAV in favJoin.DefaultIfEmpty()
                             where PRO.Estado == pEstado &&
                                   PRO.Stock > 0
                             select new ProductoDTO
                             {
                                 Id = PRO.Id,
                                 Nombre = PRO.Nombre,
                                 Descripcion = PRO.Descripcion,
                                 Estado = (bool)PRO.Estado ? true : false,
                                 Precio = (decimal)PRO.Precio,
                                 Stock = (decimal)PRO.Stock,
                                 SKU = PRO.SKU,
                                 Favorito = FAV != null
                             }).Take(200).ToList();
                }


                res.Respuesta = "OK";
                res.Lista_Productos = lista;

                return res;

            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }

        public csListaProducto getProductosSync(bool? pEstado, int? UsuarioID)
        {

            csListaProducto res = new csListaProducto();

            try
            {

                

                List<ProductoDTO> lista;

                if (pEstado == null)
                {
                    lista = (from PRO in _context.Productos
                             select new ProductoDTO
                             {
                                 Id = PRO.Id,
                                 Nombre = PRO.Nombre,
                                 Descripcion = PRO.Descripcion,
                                 Estado = (bool)PRO.Estado ? true : false,
                                 Precio = (decimal)PRO.Precio,
                                 Stock = (decimal)PRO.Stock,
                                 SKU = PRO.SKU
                             }).ToList();
                }
                else
                {
                    if (UsuarioID == null)
                    {
                        res.Respuesta = "ERROR";
                        res.Mensaje = "Error al consultar el usuario ID";
                        return res;
                    }


                    lista = (from PRO in _context.Productos
                             join FAV in _context.ProductosFavoritos
                                on new { ProductoID = PRO.Id, UsuarioID = (int)UsuarioID }
                                equals new { ProductoID = FAV.ProductoId, UsuarioID = FAV.UsuarioId }
                               into favJoin
                             from FAV in favJoin.DefaultIfEmpty()
                             where PRO.Estado == pEstado &&
                                   PRO.Stock > 0
                             select new ProductoDTO
                             {
                                 Id = PRO.Id,
                                 Nombre = PRO.Nombre,
                                 Descripcion = PRO.Descripcion,
                                 Estado = (bool)PRO.Estado ? true : false,
                                 Precio = (decimal)PRO.Precio,
                                 Stock = (decimal)PRO.Stock,
                                 SKU = PRO.SKU,
                                 Favorito = FAV != null
                             }).ToList();
                }


                res.Respuesta = "OK";
                res.Lista_Productos = lista;

                return res;

            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }

        public csListaProducto getProductosWeb(bool? pEstado, int? UsuarioID)
        {

            csListaProducto res = new csListaProducto();

            try
            {

                

                List<ProductoDTO> lista;

                if (pEstado == null)
                {
                    lista = (from PRO in _context.Productos
                             select new ProductoDTO
                             {
                                 Id = PRO.Id,
                                 Nombre = PRO.Nombre,
                                 Descripcion = PRO.Descripcion,
                                 Estado = (bool)PRO.Estado ? true : false,
                                 Precio = (decimal)PRO.Precio,
                                 Stock = (decimal)PRO.Stock,
                                 SKU = PRO.SKU
                             }).Take(200).ToList();
                }
                else
                {
                    if (UsuarioID == null)
                    {
                        res.Respuesta = "ERROR";
                        res.Mensaje = "Error al consultar el usuario ID";
                        return res;
                    }

                    var consulta = from PRO in _context.Productos
                                   join FAV in _context.ProductosFavoritos
                                      on new { ProductoID = PRO.Id, UsuarioID = (int)UsuarioID }
                                      equals new { ProductoID = FAV.ProductoId, UsuarioID = FAV.UsuarioId }
                                     into favJoin
                                   from FAV in favJoin.DefaultIfEmpty()
                                   where PRO.Estado == pEstado &&
                                         PRO.Stock > 0
                                   select new { PRO, FAV };

                    lista = consulta.AsEnumerable().Select(x => new ProductoDTO
                    {
                        Id = x.PRO.Id,
                        Nombre = x.PRO.Nombre,
                        Descripcion = x.PRO.Descripcion,
                        Estado = (bool)x.PRO.Estado ? true : false,
                        Precio = (decimal)x.PRO.Precio,
                        Stock = (decimal)x.PRO.Stock,
                        SKU = x.PRO.SKU,
                        Favorito = x.FAV != null
                    }).Take(200).ToList();
                }


                res.Respuesta = "OK";
                res.Lista_Productos = lista;

                return res;

            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }

        public csListaProducto getProductosPalabraClave(string pPalabraClave)
        {
            csListaProducto res = new csListaProducto();
            try
            {
                string terminoFT = PrepararTermino(pPalabraClave);

                string query = @"
                            SELECT Id, Nombre, Precio, Descripcion, Estado, SKU, Stock, CAST(0 AS BIT) AS Favorito
                            FROM Productos
                            WHERE Estado = 1
                              AND (
                                  CONTAINS(Nombre, @termino)
                                  OR CONTAINS(Descripcion, @termino)
                                  OR CONTAINS(SKU, @termino)
                              )";

                var param = new SqlParameter("@termino", SqlDbType.NVarChar) { Value = terminoFT };

                List<ProductoDTO> lista = _context.Database
                    .SqlQueryRaw<ProductoDTO>(query, param)
                    .Take(200)
                    .ToList();

                res.Respuesta = "OK";
                res.Lista_Productos = lista;

                return res;
            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }

        private string PrepararTermino(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return "\"*\"";

            var palabras = termino.Trim()
                                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(" AND ", palabras.Select(p => $"\"{p}*\""));
        }


        public csProducto getProducto(int id, string SKU)
        {
            csProducto res = new csProducto();

            try
            {

                


                var producto = (from PRO in _context.Productos
                                where PRO.Id == id && PRO.SKU == SKU
                                select new ProductoDTO
                                {
                                    Id = PRO.Id,
                                    Nombre = PRO.Nombre,
                                    Descripcion = PRO.Descripcion,
                                    Estado = (bool)PRO.Estado ? true : false,
                                    Precio = (decimal)PRO.Precio,
                                    Stock = (decimal)PRO.Stock,
                                    SKU = PRO.SKU
                                }).FirstOrDefault();



                res.Respuesta = "OK";
                res.Producto = producto;

                return res;

            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }

        public Resultado crearProducto(ProductoDTO prod)
        {
            Resultado res = new Resultado();
            try
            {

                

                var lValidar = (from PRO in _context.Productos
                                where PRO.SKU == prod.SKU
                                select PRO).Count();

                if (lValidar > 0)
                {

                    res.Respuesta = "ERROR";
                    res.Mensaje = "El proucto con el SKU " + prod.SKU + " ya existe";
                    return res;

                }

                Producto producto = new Producto
                {
                    Id = prod.Id,
                    Nombre = prod.Nombre,
                    Precio = prod.Precio,
                    Descripcion = prod.Descripcion,
                    Estado = true,
                    SKU = prod.SKU,
                    Stock = prod.Stock
                };

                _context.Productos.Add(producto);
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


        public Resultado inactivarProducto(int id, string SKU)
        {
            Resultado res = new Resultado();

            try
            {

                


                var producto = (from PRO in _context.Productos
                                where PRO.Id == id && PRO.SKU == SKU
                                select PRO).FirstOrDefault();

                if (producto == null)
                {

                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto no existe";

                    return res;

                }
                else if (producto != null && producto.Estado == false)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto ya se encuentra inactivo";
                    return res;
                }

                producto.Estado = false;
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

        public Resultado activarProducto(int id, string SKU)
        {
            Resultado res = new Resultado();

            try
            {

                


                var producto = (from PRO in _context.Productos
                                where PRO.Id == id && PRO.SKU == SKU
                                select PRO).FirstOrDefault();

                if (producto == null)
                {

                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto no existe";

                    return res;

                }
                else if (producto != null && producto.Estado == true)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto ya se encuentra activo";
                    return res;
                }

                producto.Estado = true;
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


        public Resultado editProducto(ProductoDTO prod)
        {
            Resultado res = new Resultado();

            try
            {
                



                var producto = (from PRO in _context.Productos
                                where PRO.Id == prod.Id && PRO.SKU == prod.SKU
                                select PRO).FirstOrDefault();

                if (producto == null)
                {

                    res.Respuesta = "ERROR";
                    res.Mensaje = "El producto no existe";

                    return res;

                }

                producto.Nombre = prod.Nombre;
                producto.Precio = prod.Precio;
                producto.Descripcion = prod.Descripcion;
                producto.Stock = prod.Stock;


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

        public csListaProducto getProductosFavoritos(int UsuarioID)
        {

            csListaProducto res = new csListaProducto();

            try
            {

                

                List<ProductoDTO> lista;

                if (UsuarioID == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "Error al consultar el usuario ID";
                    return res;
                }


                lista = (from PRO in _context.Productos
                         join FAV in _context.ProductosFavoritos
                            on new { ProductoID = PRO.Id }
                            equals new { ProductoID = FAV.ProductoId }
                         where PRO.Stock > 0 &&
                               FAV.UsuarioId == UsuarioID &&
                                PRO.Estado == true
                         select new ProductoDTO
                         {
                             Id = PRO.Id,
                             Nombre = PRO.Nombre,
                             Descripcion = PRO.Descripcion,
                             Estado = (bool)PRO.Estado ? true : false,
                             Precio = (decimal)PRO.Precio,
                             Stock = (decimal)PRO.Stock,
                             SKU = PRO.SKU,
                             Favorito = FAV != null
                         }).ToList();



                res.Respuesta = "OK";
                res.Lista_Productos = lista;

                return res;

            }
            catch (Exception ex)
            {
                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
        }


        public Resultado agregarFavorito(int ProductoID, int UsuarioID)
        {
            Resultado res = new Resultado();

            try
            {

                


                var producto = (from PRO in _context.ProductosFavoritos
                                where PRO.UsuarioId == UsuarioID &&
                                       PRO.ProductoId == ProductoID
                                select PRO).FirstOrDefault();

                if (producto != null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El usuario ya tiene agregado el producto en favoritos";
                    return res;
                }

                ProductosFavorito productoFavorito = new ProductosFavorito();
                productoFavorito.ProductoId = ProductoID;
                productoFavorito.UsuarioId = UsuarioID;

                _context.ProductosFavoritos.Add(productoFavorito);

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

        public Resultado eliminarFavorito(int ProductoID, int UsuarioID)
        {
            Resultado res = new Resultado();

            try
            {

                


                var producto = (from PRO in _context.ProductosFavoritos
                                where PRO.UsuarioId == UsuarioID &&
                                       PRO.ProductoId == ProductoID
                                select PRO).FirstOrDefault();

                if (producto == null)
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = "El usuario no tiene agregado el producto en favoritos";
                    return res;
                }

                _context.ProductosFavoritos.Remove(producto);


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

    }
}