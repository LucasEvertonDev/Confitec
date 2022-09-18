using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Application.Services.Intefaces
{
    public interface IUsuarioService<TBaseModel> : IService<TBaseModel> where TBaseModel : BaseModel
    {
    }
}
