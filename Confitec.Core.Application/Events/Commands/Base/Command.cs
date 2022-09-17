using Confitec.Infra.Utils.Utils;
using FluentValidation;

namespace Confitec.Core.Application.Events.Commands.Base
{
    public abstract class Command : ICommand
    {
        public Command()
        {
            Erros = new List<string>();
        }

        public List<string> Erros { get; set; }

        public virtual bool IsValid<TCommand>() where TCommand : Command
        {
            var validator = EngineContext.GetService<IValidator<TCommand>>() ;
            if(validator != null)
            {
                var validationResult = ((IValidator<TCommand>)validator).Validate((TCommand)this);
               
                if(validationResult != null)
                {
                    validationResult.Errors.ForEach(e => Erros.Add(e.ErrorMessage));
                }
            }

            return Erros == null || !Erros.Any();
        }
    }
}
