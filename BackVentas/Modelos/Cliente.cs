using System;
using System.Collections.Generic;

namespace BackVentas.Modelos;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public int IdCategoria { get; set; }

    public int Identificacion { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
