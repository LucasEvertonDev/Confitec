using Confitec.Core.Model.Models.Base;
using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Model.Dtos
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
        }

        public List<string> Errors { get; set; }

        public bool Success { get => Errors == null || !Errors.Any(); }
    }

    public class ResponseDTO<TModel> : ResponseDTO
    {
        public ResponseDTO() : base()
        {
        }

        public TModel Data { get; set; }
    }
}
