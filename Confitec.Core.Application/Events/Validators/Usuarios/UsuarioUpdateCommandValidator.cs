using Confitec.Core.Application.Events.Commands.Usuarios;
using FluentValidation;

namespace Confitec.Core.Application.Events.Validators.Usuarios
{
    public class UsuarioUpdateCommandValidator : AbstractValidator<UsuariosUpdateCommand>
    {
        public UsuarioUpdateCommandValidator()
        {
            RuleFor(a => a.Id).Must(b => b == 0).WithMessage("O campo id é obtogatório"); 
        }
    }
}
