using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Application.Events.Handlers.Base
{
    public class EventHandlerBase 
    {
        public async Task<TResponse> OnHandler<TResponse, TRequest>(TRequest request,
            Func<TRequest, Task<TResponse>> onHandlerFunc)
            where TRequest : Command
            where TResponse : Response
        {
            var response = App.Init<TResponse>();
            response.Errors = new List<string>();
            try
            {
                if (!request.IsValid<TRequest>())
                {
                    response.Errors.AddRange(request.Erros);
                }
                else
                {
                    response = await onHandlerFunc(request);
                }
            }
            catch
            {
                response.Errors.Add("Não foi possível concluir a operação tente novamente mais tarde");
            }
            return response;
        }
    }
}
