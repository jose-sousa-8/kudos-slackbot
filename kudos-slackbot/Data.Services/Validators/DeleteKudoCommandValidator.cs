namespace KudosSlackbot.Data.Services.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Domain.Services;

    public class DeleteKudoCommandValidator : KudoSlashCommandValidator<DeleteKudoCommand>
    {
        public override IValidationResult Validate(DeleteKudoCommand kudoCommand)
        {
            var validationResult = this.ValidateDeleteKudoCommandAction(kudoCommand);

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }


        private IValidationResult ValidateDeleteKudoCommandAction(DeleteKudoCommand kudoCommand)
        {
            var errors = new List<string>();

            var parcels = kudoCommand.CommandText.Split(' ');

            if (parcels.Length != 2)
            {
                errors.Add("Invalid kudo delete command. It should be in format /kudo delete <kudo-id>");
            }

            if (!Guid.TryParse(parcels.ElementAt(1), out Guid guid))
            {
                errors.Add("Invalid guid format.");
            }

            return new ValidationResult { Errors = errors };
        }
    }
}
