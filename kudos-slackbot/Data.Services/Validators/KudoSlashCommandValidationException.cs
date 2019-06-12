namespace KudosSlackbot.Data.Services.Validators
{
    using System;
    using System.Runtime.Serialization;

    using KudosSlackbot.Domain.Services;

    [Serializable]
    public class KudoSlashCommandValidationException : Exception
    {
        protected KudoSlashCommandValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        public KudoSlashCommandValidationException(IValidationResult validationResult) : base(validationResult.ErrorMessage)
        {
        }
    }
}
