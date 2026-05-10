using System;
using System.Collections.Generic;

namespace BackVentas.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Nit { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<AsignacionCliente> AsignacionClientes { get; set; } = new List<AsignacionCliente>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
