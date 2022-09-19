using Confitec.Core.Model.Models;
using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Application.Services.Intefaces
{
    public interface IEscolaridadeService<TBaseModel> : IService<TBaseModel> where TBaseModel : BaseModel 
    {
    }
}