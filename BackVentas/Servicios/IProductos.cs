using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BackVentas.Servicios
{
    public interface IProductos
    {

        public ProductoViewModel crearProducto(ProductoViewModel prod);
        public ProductoViewModel getProducto(int id);
        public List<ProductoViewModel> getProductosActivos(); 
        public List<ProductoViewModel> getProductosAll();
        public string deleteProducto(int id);
        public string inactivarProducto(int id);
        public string activarProducto(int id);
        public ProductoViewModel editProducto(ProductoViewModel prod);
    }
}
