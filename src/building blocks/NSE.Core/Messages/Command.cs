using FluentValidation.Results;
using System;

namespace NSE.Core.Messages
{
    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
