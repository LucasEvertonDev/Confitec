namespace Confitec.Infra.Utils.Utils
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
