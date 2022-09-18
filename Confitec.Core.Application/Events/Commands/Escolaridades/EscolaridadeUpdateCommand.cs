using Confitec.Core.Application.Events.Commands.Base;

namespace Confitec.Core.Application.Events.Commands.Escolaridades
{
    public class EscolaridadeUpdateCommand : EscolaridadeCommand, IBaseCommand
    {
        public int Id { get; set; }
    }
}
