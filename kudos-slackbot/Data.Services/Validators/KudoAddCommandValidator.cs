namespace KudosSlackbot.Data.Services.Validators
{
    using System.Linq;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Domain.Services;

    public class KudoAddCommandValidator : KudoSlashCommandTextValidator<CreateKudoCommand>
    {
        public override IValidationResult Validate(CreateKudoCommand kudoCommand)
        {
            ValidationResult validationResult = new ValidationResult();

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }
    }
}
