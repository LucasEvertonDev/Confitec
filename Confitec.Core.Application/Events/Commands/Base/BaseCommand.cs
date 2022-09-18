using Confitec.Infra.Utils.Exceptions;
using Confitec.Infra.Utils.Utils;
using FluentValidation;
using FluentValidation.Results;

namespace Confitec.Core.Application.Events.Commands.Base
{
    public class BaseCommand : IBaseCommand
    {
        public virtual void ValidateCommand<TCommand>()
        {
            var validator = EngineContext.GetService<IValidator<TCommand>>();
            if (validator != null)
            {
                ValidationResult validationResult = validator.Validate((dynamic)this);

                if (validationResult != null)
                {
                    if (validationResult.Errors.Any())
                    {
                        throw new ValidatorException(validationResult.Errors.Select(a => a.ErrorMessage).ToList());
                    }
                }
            }
        }
    }
}
