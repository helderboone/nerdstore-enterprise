using FluentValidation.Results;

namespace NSE.Core.Messages
{
    public abstract class CommandHandler
    {
        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult;

        public void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}
