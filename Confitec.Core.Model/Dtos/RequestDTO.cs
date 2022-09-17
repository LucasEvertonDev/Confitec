using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Model.Dtos
{
    public class RequestDTO
    {
        public int Id { get; set; }
    }

    public class RequestDTO<TModel> where TModel : BaseModel
    {
        public TModel Data { get; set; }
    }

}
