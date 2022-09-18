using Confitec.Core.Model.Dtos;
using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Application.Services.Intefaces
{
    public interface IService<TBaseModel> where TBaseModel : BaseModel
    {
        Task<ResponseDTO<TBaseModel>> CreateAsync(RequestDTO<TBaseModel> requestDTO);

        Task<ResponseDTO> DeleteAsync(int id);

        Task<ResponseDTO<TBaseModel>> UpdateAsync(RequestDTO<TBaseModel> requestDTO);

        Task<ResponseDTO<IEnumerable<TBaseModel>>> FindAllAsync();

        Task<ResponseDTO<TBaseModel>> FindByIdAsync(int id);
    }
}