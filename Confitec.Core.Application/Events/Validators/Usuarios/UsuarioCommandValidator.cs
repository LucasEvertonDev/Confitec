using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using Confitec.Infra.Utils.Utils;
using FluentValidation;

namespace Confitec.Core.Application.Events.Validators.Usuarios
{
    public abstract class UsuarioCommandValidator<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        private readonly IEscolaridadeService _escolaridadeService;

        public UsuarioCommandValidator()
        {
            _escolaridadeService = (IEscolaridadeService)EngineContext.GetService<IEscolaridadeService>();
        }

        protected void ValidateUserCommand()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage("O campo nome é obrigatório")
                .MaximumLength(30).WithMessage("O campo nome deve ter no máximo 30 caracteres");

            RuleFor(a => a.Sobrenome).NotEmpty().WithMessage("O campo sobrenome é obrigatório")
                .MaximumLength(30).WithMessage("O campo sobrenome deve ter no máximo 30 caracteres");

            RuleFor(a => a.Email).NotEmpty().WithMessage("O campo nome é obrigatório")
                .EmailAddress().WithMessage("O campo email é inválido")
                .MaximumLength(50).WithMessage("O campo nome deve ter no máximo 50 caracteres");

            RuleFor(a => a.DataNascimento).NotEqual(DateTime.MinValue).WithMessage("O campo data nascimento é obrigatório")
                .Must(a => a <= DateTime.Now).WithMessage("A data de nascimento não pode ser superior a atual");

            RuleFor(a => a.EscolaridadeId).NotEmpty().WithMessage("O campo escolaridade é obrigatório")
                .Must(a => IsValidEscolaridade(a)).WithMessage("O campo escolaridade é inválido por favor revise as documentações");
        
        }
   
        private bool IsValidEscolaridade(int id)
        {
            var escolaridades = Task.Run(async () => await _escolaridadeService.FindAllAsync()).Result ?? new List<EscolaridadeModel>();
            return escolaridades.Exists(e => e.Id == id);
        }
    }
}
