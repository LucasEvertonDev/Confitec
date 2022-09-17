using Confitec.Core.Model.Models.Base;
using Confitec.Infra.Utils.Utils;

namespace Confitec.Core.Model.Dtos
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        public bool Success { get => !Errors.Any(); }
    }

    public class ResponseDTO<TModel> : ResponseDTO where TModel : IBaseModel
    {
        public ResponseDTO() : base()
        {
            Data = App.Init<TModel>();
        }

        public TModel Data { get; set; }
    }

    public class ResponseSerchDTO<TList> : ResponseDTO where TList : List<IBaseModel>
    {
        public ResponseSerchDTO() : base()
        {
            Itens = App.Init<TList>();
        }

        public TList Itens { get; set; }
    }
}
