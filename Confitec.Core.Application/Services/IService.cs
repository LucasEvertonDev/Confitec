using Confitec.Core.Application.DTOs;

namespace Confitec.Core.Application.Services
{
    public interface IService<TDto> where TDto : IDtoBase
    {
        Task<TDto?> Create(TDto dto);
        Task Delete(int id);
        Task<TDto?> Update(TDto dto);
    }
}