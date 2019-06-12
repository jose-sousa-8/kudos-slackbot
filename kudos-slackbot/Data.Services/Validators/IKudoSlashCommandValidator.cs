namespace KudosSlackbot.Domain.Services
{
    public interface IKudoSlashCommandValidator<in T>
    {
        IValidationResult Validate(T kudoCommand);
    }
}