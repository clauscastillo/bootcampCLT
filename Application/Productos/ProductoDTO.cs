namespace bootcampCLT.Application.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public int CategoriaId { get; set; }
        public int CantidadStock { get; set; }
    }

}
