using AutoMapper;
using BibliotecaAPI.Dtos;
using BibliotecaAPI.Entidades;

namespace BibliotecaAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Autor, AutorDTO>().ForMember(dto => dto.NombreCompleto, config => config.MapFrom(autor => $"{autor.Nombres} {autor.Apellidos}"));

            CreateMap<AutorCreacionDto, Autor>();
        }
    }
}
