
namespace KudosSlackbot.Domain.Services
{
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public abstract class KudoSlashCommandTextValidator<T> : IKudoSlashCommandValidator<T> where T : IKudoRequest
    {
        protected const string SlackIdRegex = "^(<@U)[a-zA-Z0-9]*|.*>";

        public abstract IValidationResult Validate(T kudoCommand);
    }
}