namespace BibliotecaAPI.Dtos;

public class ComentarioDTO
{
    public Guid Id { get; set; }
    public required string Cuerpo { get; set; }
    public DateTime FechaPublicacion { get; set; }
}