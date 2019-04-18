
namespace KudosSlackbot.Domain.Services
{

    using KudosSlackbot.Application.Commands;

    public abstract class KudoSlashCommandTextValidator<T> : IKudoSlashCommandValidator<T> where T : IKudoCommand
    {
        public abstract IValidationResult Validate(T kudoCommand);
    }
}