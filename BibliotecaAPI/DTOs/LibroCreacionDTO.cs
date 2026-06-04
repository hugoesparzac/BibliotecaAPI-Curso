using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Dtos;

public class LibroCreacionDTO
{
    [Required]
    public required string Titulo { get; set; }
    public int AutorId { get; set; }
}