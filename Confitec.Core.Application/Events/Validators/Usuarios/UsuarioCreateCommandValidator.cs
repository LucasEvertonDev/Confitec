using Confitec.Core.Application.Events.Commands.Usuarios;
using FluentValidation;

namespace Confitec.Core.Application.Events.Validators.Usuarios
{
    public class UsuarioCreateCommandValidator : UsuarioCommandValidator<UsuariosCreateCommand>
    {
        public UsuarioCreateCommandValidator()
        {
            ValidateUserCommand();
        }
    }
}
