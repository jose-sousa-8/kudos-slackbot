namespace KudosSlackbot.Data.Services.Validators
{
    using System;

    using KudosSlackbot.Domain.Services;

    public class KudoSlashCommandValidationException : Exception
    {
        public KudoSlashCommandValidationException(IValidationResult validationResult) : base(validationResult.ErrorMessage)
        {
        }
    }
}
