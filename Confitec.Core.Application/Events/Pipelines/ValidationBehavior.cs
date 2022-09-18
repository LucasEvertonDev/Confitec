using Confitec.Core.Application.Events.Commands.Base;
using MediatR;

namespace Confitec.Core.Application.Events.Pipelines
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public ValidationBehaviour()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IBaseCommand) // Queries não tem validação ou não deveriam pois não faz sentido
            {
                ((IBaseCommand)request).ValidateCommand<TRequest>();
            }

            return await next();
        }
    }
}
