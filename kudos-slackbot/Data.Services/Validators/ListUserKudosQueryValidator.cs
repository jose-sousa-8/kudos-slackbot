namespace KudosSlackbot.Data.Services.Validators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Domain.Services;

    public class ListUserKudosQueryValidator : KudoSlashCommandValidator<ListUserKudosQuery>
    {
        public override IValidationResult Validate(ListUserKudosQuery listUserKudosQuery)
        {
            var validationResult = this.ValidateListUserKudosQuery(listUserKudosQuery);

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }


        private IValidationResult ValidateListUserKudosQuery(ListUserKudosQuery listUserKudosQuery)
        {
            var errors = new List<string>();

            var parcels = listUserKudosQuery.Text.Split(' ');

            if (parcels.Length != 2)
            {
                errors.Add("Invalid user list command. It should be in format /kudo <user-id>.");
            }
            var userInfo = listUserKudosQuery.Text.Split(' ')[1];

            if (!Regex.IsMatch(userInfo, SlackIdRegex))
            {
                errors.Add($"Invalid user information.");
            }

            return new ValidationResult { Errors = errors };
        }
    }
}
