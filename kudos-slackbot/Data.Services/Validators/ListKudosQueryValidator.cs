namespace KudosSlackbot.Data.Services.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Domain.Services;

    public class ListKudosQueryValidator : KudoSlashCommandTextValidator<ListKudosQuery>
    {
        private const string InvalidQueryText = "Invalid list command. It should be in format /kudo list <n> where n is an integer or * for all kudos.";

        public override IValidationResult Validate(ListKudosQuery listKudosQuery)
        {
            var validationResult = this.ValidateListKudosQuery(listKudosQuery);

            if (validationResult.Errors.Any())
            {
                throw new KudoSlashCommandValidationException(validationResult);
            }

            return validationResult;
        }


        private IValidationResult ValidateListKudosQuery(ListKudosQuery listKudosQuery)
        {
            var errors = new List<string>();

            var parcels = listKudosQuery.Text.Split(' ');

            if (parcels.Length != 2)
            {
                errors.Add("Invalid list command. It should be in format /kudo list <n> where n is an integer or * for all kudos.");
            }

            if (!parcels[1].Equals("*") && !int.TryParse(parcels[1], out int nKudos))
            {
                errors.Add($"{InvalidQueryText}{Environment.NewLine}Instead received {parcels[1]}.");
            }

            return new ValidationResult { Errors = errors };
        }
    }
}
