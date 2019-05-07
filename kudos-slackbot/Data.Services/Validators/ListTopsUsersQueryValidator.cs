namespace KudosSlackbot.Data.Services.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Domain.Services;

    public class ListTopUsersQueryValidator : KudoSlashCommandValidator<ListTopUsersQuery>
    {
        public override IValidationResult Validate(ListTopUsersQuery listUserKudosQuery)
        {
            var validationResult = this.ValidateListUserKudosQuery(listUserKudosQuery);

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }


        private IValidationResult ValidateListUserKudosQuery(ListTopUsersQuery listUserKudosQuery)
        {
            var errors = new List<string>();

            var parcels = listUserKudosQuery.Text.Split(' ');

            if (parcels.Length != 2)
            {
                errors.Add("Invalid user list command. It should be in format /kudo <user-id>.");
            }

            var numberOfUsers = parcels[1];

            if (!numberOfUsers.Equals("*"))
            {
                if (!Int32.TryParse(numberOfUsers, out int n) || n <= 0)
                {
                    errors.Add("Invalid top list command. It should be in format /kudo top n, where n > 0 or n = *");
                }
            }

            return new ValidationResult { Errors = errors };
        }
    }
}
