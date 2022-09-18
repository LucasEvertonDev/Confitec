using Confitec.Core.Application.Events.Commands.Escolaridades;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Queries.Escolaridades;
using Confitec.Core.Model.Models;

namespace Confitec.Core.Application.Events.Contracts
{
    public class EscolaridadeEventsContract : IEventsContract<EscolaridadeModel>
    {
        public Type CreateCommand => typeof(EscolaridadeCreateCommand);

        public Type UpdateCommand => typeof(EscolaridadeUpdateCommand);

        public Type DeleteCommand => typeof(EscolaridadeDeleteCommand);

        public Type GetAllQuery => typeof(GetAllEscolaridadesQuery);

        public Type GetByIdQuery => typeof(GetEscolaridadeByIdQuery);
    }
}
