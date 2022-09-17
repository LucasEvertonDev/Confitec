using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Base;
using MediatR;
using NetDevPack.Messaging;

namespace Confitec.Core.Application.Events.Commands.Usuarios
{
    public abstract class UsuarioCommand : IRequest<UsuarioDto>, ICommand
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }

        public int HistoricoEscolarId { get; set; }
    }
}
