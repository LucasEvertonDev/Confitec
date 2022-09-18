using AutoMapper;
using Confitec.Core.Application.Events.Commands.Escolaridades;
using Confitec.Core.Application.Events.Queries.Escolaridades;
using Confitec.Core.Application.Mappings.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Model.Models;

namespace Confitec.Core.Application.Mappings
{
    public class EscolaridadeMapperProfile : BaseMapperProfile
    {
        public EscolaridadeMapperProfile() : base() { }

        public override void CommandToEntity()
        {
            CreateMap<EscolaridadeUpdateCommand, Escolaridade>().ReverseMap();
            CreateMap<EscolaridadeCreateCommand, Escolaridade>().ReverseMap();
            CreateMap<EscolaridadeDeleteCommand, Escolaridade>().ReverseMap();
            CreateMap<EscolaridadeCommand, Escolaridade>().ReverseMap();
        }

        public override void EntityToModel()
        {
            CreateMap<Escolaridade, EscolaridadeModel>().ReverseMap();
        }

        public override void ModelToCommand()
        {
            CreateMap<EscolaridadeModel, EscolaridadeCommand>().ReverseMap();
            CreateMap<EscolaridadeModel, EscolaridadeCreateCommand>().ReverseMap();
            CreateMap<EscolaridadeModel, EscolaridadeUpdateCommand>().ReverseMap();
            CreateMap<EscolaridadeModel, EscolaridadeDeleteCommand>().ReverseMap();
        }

        public override void ModelToQuery()
        {
            CreateMap<EscolaridadeModel, GetEscolaridadeByIdQuery>().ReverseMap();
        }
    }
}
