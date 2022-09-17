using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Application.Events.Dtos
{
    public class Response
    {
        public Response()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
    }

    public class Response<TResponse> : Response
    {
        public Response()
        {
            Result = App.Init<TResponse>();
        }

        public TResponse Result { get; set; }
    }
}
