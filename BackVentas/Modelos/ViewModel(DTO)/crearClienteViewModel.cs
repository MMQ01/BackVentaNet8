namespace BackVentas.Modelos.ViewModel_DTO_
{
    public class crearClienteViewModel
    {


        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public DateTime? FechaCreacion { get; set; }

        public string? Estado { get; set; }

        public int IdCategoria { get; set; }
        public int Identificacion { get; set; }

    }
}
