using Confitec.Core.Model.Dtos;
using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Application.Services.Intefaces
{
    public interface IService<TBaseModel> where TBaseModel : BaseModel
    {
        Task<ResponseDTO<TBaseModel>> CreateAsync(RequestDTO<TBaseModel> requestDTO);

        Task<ResponseDTO> DeleteAsync(RequestDTO requestDTO);

        Task<ResponseDTO<TBaseModel>> UpdateAsync(RequestDTO<TBaseModel> requestDTO);
    }
}