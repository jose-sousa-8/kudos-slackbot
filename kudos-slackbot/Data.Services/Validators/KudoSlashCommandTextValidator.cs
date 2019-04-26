
namespace KudosSlackbot.Domain.Services
{

    using KudosSlackbot.Application.Commands;

    public abstract class KudoSlashCommandTextValidator<T> : IKudoSlashCommandValidator<T> where T : IKudoCommand
    {
        protected const string SlackIdRegex = "^(<@U)[a-zA-Z0-9]*|.*>";

        public abstract IValidationResult Validate(T kudoCommand);
    }
}