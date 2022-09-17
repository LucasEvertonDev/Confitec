using Confitec.Core.Model.Models;

namespace Confitec.Core.Application.Services.Intefaces
{
    public interface IEscolaridadeService
    {
        Task<List<EscolaridadeModel>> FindAllAsync();
    }
}