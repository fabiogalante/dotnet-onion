using System.Linq;
using FluentValidation.Results;

namespace Dotnet.Onion.Template.Domain.Base
{
    public abstract class Entity
    {
       
        public ValidationResult ValidationResult { get; protected set; }
        public string[] ErrorMessages => ValidationResult?.Errors?.Select(a => a.ErrorMessage)?.ToArray();

        public abstract bool IsValid();
    }
}
