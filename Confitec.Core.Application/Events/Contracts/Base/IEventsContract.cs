using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Application.Events.Contracts.Base
{
    public interface IEventsContract<TBaseModel> where TBaseModel : IBaseModel
    {
        public Type CreateCommand { get; }

        public Type UpdateCommand { get; }

        public Type DeleteCommand { get; }

        public Type GetAllQuery { get; }
    }
}
