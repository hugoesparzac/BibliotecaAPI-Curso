using AutoMapper;
using BibliotecaAPI.Dtos;
using BibliotecaAPI.Entidades;

namespace BibliotecaAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(dto => dto.NombreCompleto,
                    config => config.MapFrom(autor => MapearNombreYApellidoAutor(autor)));
            
            CreateMap<Autor, AutorConLibrosDTO>()
                .ForMember(dto => dto.NombreCompleto,
                    config => config.MapFrom(autor => MapearNombreYApellidoAutor(autor)));

            CreateMap<Libro, LibroConAutorDTO>()
                .ForMember(dto => dto.AutorNombre, conf =>
                    conf.MapFrom(ent => MapearNombreYApellidoAutor(ent.Autor!)));

            CreateMap<AutorCreacionDto, Autor>();
            CreateMap<Autor, AutorPatchDTO>().ReverseMap();

            CreateMap<Libro, LibroDTO>();
            CreateMap<LibroCreacionDTO, Libro>();
            
            CreateMap<ComentarioCreacionDTO, Comentario>();
            CreateMap<Comentario, ComentarioDTO>();
            CreateMap<ComentarioPatchDTO, Comentario>().ReverseMap();
        }
        
        private string MapearNombreYApellidoAutor(Autor autor) => $"{autor.Nombres} {autor.Apellidos}";
    }
}
