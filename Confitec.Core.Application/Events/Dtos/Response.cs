using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Application.Events.Dtos
{
    public class Response
    {
        public Response()
        {
        }
    }

    public class Response<TResponse> : Response
    {
        public Response()
        {
        }

        public TResponse Result { get; set; }
    }
}
