using System.ComponentModel.DataAnnotations;
using BibliotecaAPI.Validaciones;

namespace BibliotecaAPI.Dtos;

public class AutorPatchDTO
{
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(100, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos")]
    [PrimeraLetraMayuscula]
    public required string Nombres { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(100, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos")]
    [PrimeraLetraMayuscula]
    public required string Apellidos { get; set; }
    [StringLength(20, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos")]
    public string? Identificacion { get; set; }
}