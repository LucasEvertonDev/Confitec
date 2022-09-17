using AutoMapper;
using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Domain.Entities;

namespace Confitec.Core.Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UsuarioDto, UsuarioCommand>().ReverseMap();
            CreateMap<UsuarioDto, UsuariosCreateCommand>().ReverseMap();
            CreateMap<UsuarioDto, UsuariosUpdateCommand>().ReverseMap();

            CreateMap<UsuarioDto, Usuario>().ReverseMap();

            CreateMap<Usuario, UsuariosUpdateCommand>().ReverseMap();
            CreateMap<Usuario, UsuariosCreateCommand>().ReverseMap();
            CreateMap<Usuario, UsuarioCommand>().ReverseMap();
        }
    }
}
