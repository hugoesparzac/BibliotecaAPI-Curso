using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return
            [
                new() {Id = 1, Nombre = "Hugo Esparza"},
                new() {Id = 2, Nombre = "Claudia Gonzales"}
            ];
        }
    }
}
