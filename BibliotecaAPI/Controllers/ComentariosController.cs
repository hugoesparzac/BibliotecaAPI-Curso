using AutoMapper;
using BibliotecaAPI.Datos;
using BibliotecaAPI.Dtos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers;

[ApiController]
[Route("api/libros/{libroId:int}/comentarios")]
public class ComentariosController(AppDbContext context, IMapper mapper): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ComentarioDTO>>> Get(int libroId)
    {
        var existeLibro = await context.Libros.AnyAsync(x => x.Id == libroId);
        if (!existeLibro)
        {
            return NotFound();
        }
        var comentarios = await context.Comentarios
            .Where(x => x.LibroId == libroId)
            .OrderByDescending(x => x.FechaPublicacion)
            .ToListAsync();
        return mapper.Map<List<ComentarioDTO>>(comentarios);
    }

    [HttpGet("{id}", Name = "ObtenerComentario")]
    public async Task<ActionResult<ComentarioDTO>> Get(Guid id)
    {
        var comentario = await context.Comentarios.FirstOrDefaultAsync(x => x.Id == id);
        if (comentario is null)
        {
            return NotFound();
        }
        return mapper.Map<ComentarioDTO>(comentario);
    }

    [HttpPost]
    public async Task<ActionResult> Post(int libroId, ComentarioCreacionDTO comentarioCreacionDTO)
    {
        var existeLibro = await context.Libros.AnyAsync(x => x.Id == libroId);
        if (!existeLibro)
        {
            return NotFound();
        }

        var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
        comentario.LibroId = libroId;
        comentario.FechaPublicacion = DateTime.UtcNow;
        context.Add(comentario);
        await context.SaveChangesAsync();
        var comentarioDTO = mapper.Map<ComentarioDTO>(comentario);
        return CreatedAtRoute("ObtenerComentario", new { id = comentario.Id, libroId }, comentarioDTO);
    }
}