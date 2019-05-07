namespace KudosSlackbot.Data.Services.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Domain.Services;

    public class ReplaceKudoCommandValidator : KudoSlashCommandTextValidator<ReplaceKudoCommand>
    {
        public override IValidationResult Validate(ReplaceKudoCommand kudoCommand)
        {
            var validationResult = this.ValidateDeleteKudoCommandAction(kudoCommand);

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }


        private IValidationResult ValidateDeleteKudoCommandAction(ReplaceKudoCommand kudoCommand)
        {
            var errors = new List<string>();

            var parcels = kudoCommand.CommandText.Split(' ');

            if (parcels.Length < 3)
            {
                errors.Add("Invalid kudo replace command. It should be in format /kudo replace <kudo-id> <text>");
            }

            if (!Guid.TryParse(parcels.ElementAt(1), out Guid guid))
            {
                errors.Add("Invalid guid format.");
            }

            return new ValidationResult { Errors = errors };
        }
    }
}
