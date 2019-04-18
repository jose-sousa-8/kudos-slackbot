namespace KudosSlackbot.Domain.Services
{
    public interface IKudoSlashCommandValidator<T>
    {
        IValidationResult Validate(T kudoCommand);
    }
}