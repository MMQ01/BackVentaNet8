using System;
using System.Collections.Generic;

namespace BackVentas.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool Estado { get; set; }

    public int Categoria { get; set; }

    public virtual ICollection<AsignacionCliente> AsignacionClientes { get; set; } = new List<AsignacionCliente>();

    public virtual Categoria CategoriaNavigation { get; set; } = null!;

    public virtual ICollection<ProductosFavorito> ProductosFavoritos { get; set; } = new List<ProductosFavorito>();

    public virtual ICollection<TmpCarrito> TmpCarritos { get; set; } = new List<TmpCarrito>();
}
