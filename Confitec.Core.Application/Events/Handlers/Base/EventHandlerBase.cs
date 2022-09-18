using Confitec.Core.Application.Events.Commands.Base;
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
            catch (Exception ex)
            {
                throw new HandlerException(ex.Message);
            }
        }
    }
}
