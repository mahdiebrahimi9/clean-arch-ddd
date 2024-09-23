using Book_Application.Shared.Exceptions;
using FluentValidation;
using MediatR;
using System.Text;

namespace Book_Application.Shared
{
    public class CommandValidationBehavior<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TRespone> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespone> next)
        {
            var errors = _validators.Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(r => r != null);
            if (errors.Any())
            {
                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new InvalidCommandException(stringBuilder.ToString());
            }
            var respone = await next();
            return respone;
        }
    }
}
