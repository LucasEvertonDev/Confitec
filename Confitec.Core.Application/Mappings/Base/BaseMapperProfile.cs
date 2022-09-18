using AutoMapper;

namespace Confitec.Core.Application.Mappings.Base
{
    public abstract class BaseMapperProfile : Profile
    {
        public BaseMapperProfile()
        {
            EntityToModel();

            ModelToCommand();

            CommandToEntity();

            ModelToQuery();
        }

        public abstract void EntityToModel();

        public abstract void ModelToCommand();

        public abstract void CommandToEntity();

        public abstract void ModelToQuery();
    }
}
