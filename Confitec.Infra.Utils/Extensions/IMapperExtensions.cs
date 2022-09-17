using AutoMapper;

namespace Confitec.Infra.Utils.Extensions
{
    public static class IMapperExtensions
    {
        public static dynamic? MapDynamic(this IMapper mapper, dynamic source, Type destinationType)
        {
            return mapper.Map(source, source.GetType(), destinationType);
        }
    }
}
