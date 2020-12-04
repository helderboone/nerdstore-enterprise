using FluentValidation.Results;
using NSE.Core.Data;
using System.Threading.Tasks;

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

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
