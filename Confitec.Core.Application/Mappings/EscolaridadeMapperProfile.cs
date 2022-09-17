using AutoMapper;
using Confitec.Core.Application.Mappings.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Model.Models;

namespace Confitec.Core.Application.Mappings
{
    public class EscolaridadeMapperProfile : BaseMapperProfile
    {
        public EscolaridadeMapperProfile() : base() { }

        public override void CommandToEntity() { }

        public override void EntityToModel()
        {
            CreateMap<Escolaridade, EscolaridadeModel>();
        }

        public override void ModelToCommand() { }
    }
}
