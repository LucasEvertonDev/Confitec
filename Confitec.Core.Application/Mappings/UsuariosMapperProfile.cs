﻿using AutoMapper;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Mappings.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Model.Models;

namespace Confitec.Core.Application.Mappings
{
    public class UsuariosMapperProfile : BaseMapperProfile
    {
        public UsuariosMapperProfile() : base() { }

        public override void CommandToEntity()
        { 
            CreateMap<UsuariosUpdateCommand, Usuario>().ReverseMap();
            CreateMap<UsuariosCreateCommand, Usuario>().ReverseMap();
            CreateMap<UsuarioCommand, Usuario>().ReverseMap();
        }

        public override void EntityToModel()
        {
            CreateMap<Usuario, UsuarioModel>().ReverseMap();
        }

        public override void ModelToCommand()
        {
            CreateMap<UsuarioModel, UsuarioCommand>().ReverseMap();
            CreateMap<UsuarioModel, UsuariosCreateCommand>().ReverseMap();
            CreateMap<UsuarioModel, UsuariosUpdateCommand>().ReverseMap();
        }
    }
}
