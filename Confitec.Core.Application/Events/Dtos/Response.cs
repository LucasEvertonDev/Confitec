using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Application.Events.Dtos
{
    public class Response
    {
        public Response()
        {
        }

        public List<string> Errors { get; set; }
    }

    public class Response<TResponse> : Response
    {
        public Response()
        {
        }

        public TResponse Result { get; set; }
    }
}
