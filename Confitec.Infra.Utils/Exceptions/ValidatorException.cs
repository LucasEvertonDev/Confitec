namespace Confitec.Infra.Utils.Exceptions
{
    public class ValidatorException : Exception
    {
        public List<string> Errors { get; set; }

        public ValidatorException(List<string> errors) : base("Tratamento padrão para validação fluent")
        {
            Errors = errors;
        }
    }
}
