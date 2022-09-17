using Confitec.Core.Application.Events.Commands.Usuarios;
using FluentValidation;

namespace Confitec.Core.Application.Events.Validators.Usuarios
{
    public class UsuarioCommandValidator : AbstractValidator<UsuarioCommand> 
    {
        public UsuarioCommandValidator()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage("O campo nome é obrigatório")
                .MaximumLength(30).WithMessage("O campo nome deve ter no máximo 30 caracteres");

            RuleFor(a => a.Sobrenome).NotEmpty().WithMessage("O campo sobrenome é obrigatório")
                .MaximumLength(30).WithMessage("O campo sobrenome deve ter no máximo 30 caracteres");

            RuleFor(a => a.Email).NotEmpty().WithMessage("O campo nome é obrigatório")
                .EmailAddress().WithMessage("O campo email é inválido")
                .MaximumLength(50).WithMessage("O campo nome deve ter no máximo 50 caracteres");

            RuleFor(a => a.DataNascimento).NotEqual(DateTime.MinValue).WithMessage("O campo data nascimento é obrigatório")
                .Must(a => a > DateTime.Now).WithMessage("A data de nascimento não pode ser superior a atual");

            RuleFor(a => a.EscolaridadeId).NotEmpty().WithMessage("O campo escolaridade é obrigatório");
        }
    }
}
