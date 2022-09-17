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
        }

        public abstract void EntityToModel();

        public abstract void ModelToCommand();

        public abstract void CommandToEntity();
    }
}
