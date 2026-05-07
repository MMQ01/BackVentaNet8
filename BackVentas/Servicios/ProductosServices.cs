using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackVentas.Servicios
{
    public class ProductosServices : IProductos
    {
        private readonly VentasContext _context;
        public ProductosServices(VentasContext context)
        {
            _context = context;
        }

        public ProductoViewModel getProducto(int id)
        {
            var producto = _context.Productos
                .Where(x => x.Id == id && x.Estado == "SI")
                .Select(x => new ProductoViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    
                }).FirstOrDefault(); 



            return producto;
        }


        public List<ProductoViewModel> getProductosActivos()
        {
            var lista = _context.Productos
                .Where(x => x.Estado == "SI")
                .Select(x => new ProductoViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    Estado = x.Estado
                   
                })
                .ToList();

            return lista;
        }

        public List<ProductoViewModel> getProductosAll()
        {
            var lista = _context.Productos
                .Select(x => new ProductoViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    Estado = x.Estado

                })
                .ToList();

            return lista;
        }

        public string inactivarProducto(int id)
        {
            var producto = _context.Productos.Where(x => x.Id == id && x.Estado == "SI").FirstOrDefault();

            if (producto == null)
            {
                return "Producto ya ha sido inactivado o no existe";
            }
            producto.Estado = "NO";
            _context.SaveChanges();

            return "Producto inactivado exitosamente";

        }

        public ProductoViewModel editProducto(ProductoViewModel prod)
        {
            Producto producto = _context.Productos.Single(p=> prod.Id == p.Id && p.Estado == "SI");
            producto.Nombre = prod.Nombre;
            producto.Precio = prod.Precio;
            producto.Descripcion = prod.Descripcion;

            _context.Productos.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            ProductoViewModel productoEditado = new ProductoViewModel{
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion,
            };

            return productoEditado;
        }

        public string deleteProducto(int id)
        {
            var producto = _context.Productos.Where(x => x.Id == id && x.Estado == "SI").FirstOrDefault();

            if (producto == null)
            {
                return "Producto ya ha sido eliminado o no existe";
            }
            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return "Producto eliminado exitosamente";
        }

        public ProductoViewModel crearProducto(ProductoViewModel prod)
        {
            Producto producto = new Producto
            {
                Id = prod.Id,
                Nombre =prod.Nombre,
                Precio = prod.Precio,
                Descripcion = prod.Descripcion,
                Estado = "SI"
            };

            _context.Productos.Add(producto);
            _context.SaveChanges();

            ProductoViewModel productoCreado = new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion,
            };

            return productoCreado;
        }

        public string activarProducto(int id)
        {
            var producto = _context.Productos.Where(x => x.Id == id && x.Estado == "NO").FirstOrDefault();

            if (producto == null)
            {
                return "Producto ya ha sido activado o no existe";
            }
            producto.Estado = "SI";
            _context.SaveChanges();

            return "Producto activado exitosamente";
        }
    }
}
