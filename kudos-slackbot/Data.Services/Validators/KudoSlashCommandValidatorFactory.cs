
namespace KudosSlackbot.Data.Services.Validators
{
    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Domain.Services;

    public class KudoSlashCommandValidatorFactory<T> : IKudoSlashCommandValidatorFactory where T : IKudoCommand
    {
        public static IKudoSlashCommandValidator<T> GetValidator(T command)
        {
            var commandType = typeof(T);

            if (commandType == typeof(CreateKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new KudoAddCommandValidator();
            }

            throw new System.Exception("Uknown Kudo Command.");
        }
    }
}
