namespace KudosSlackbot.Data.Services.Validators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Domain.Services;

    public class KudoAddCommandValidator : KudoSlashCommandTextValidator<CreateKudoCommand>
    {
        public override IValidationResult Validate(CreateKudoCommand kudoCommand)
        {
            var validationResult = this.ValidateCreateKudoCommandAction(kudoCommand);

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }


        private IValidationResult ValidateCreateKudoCommandAction(CreateKudoCommand kudoCommand)
        {
            var errors = new List<string>();

            var parcels = kudoCommand.Text.Split(' ');

            if (parcels.Length < 3)
            {
                errors.Add("Invalid kudo add command. It should be in format /kudo add <slack-id> <text>");
            }

            var slackId = parcels.ElementAt(1);
            if (string.IsNullOrWhiteSpace(slackId))
            {
                errors.Add("You must specify a User Id");
            }
            else
            {
                if (!Regex.Match(slackId, SlackIdRegex).Success)
                {
                    errors.Add("Invalid user id. Use format <@U######>");
                }
            }

            return new ValidationResult { Errors = errors };
        }
    }
}
