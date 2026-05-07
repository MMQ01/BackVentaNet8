namespace BackVentas.Modelos.ViewModel_DTO_
{
    public class editarClienteViewModel
    {

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int IdCategoria { get; set; }
    }
}
