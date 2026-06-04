using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Dtos;

public class ComentarioCreacionDTO
{
    [Required]
    public required string Cuerpo { get; set; }
}