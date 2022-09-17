using Confitec.Core.Application.Events.Dtos;
using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Application.Events.Handlers.Base
{
    public class EventHandlerBase 
    {
        public async Task<TResponse> OnHandler<TResponse, TRequest>(TRequest request,
            Func<TRequest, Task<TResponse>> onHandlerFunc) 
            where TResponse : Response
        {
            try
            {
                return await onHandlerFunc(request);
            }
            catch
            {
                var response = App.Init<TResponse>();
                response.Errors.Add("Não foi possível concluir a operação tente novamente mais tarde");
                return response;
            }
        }
    }
}
