using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Commands.Usuarios
{
    public abstract class UsuarioCommand : BaseCommand, IRequest<Response<UsuarioModel>>, IBaseCommand
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }

        public int HistoricoEscolarId { get; set; }
    }
}
