namespace KudosSlackbot.Data.Services.Validators
{
    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Domain.Services;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class KudoSlashCommandValidatorFactory<T> : IKudoSlashCommandValidatorFactory where T : IKudoRequest
    {
        public static IKudoSlashCommandValidator<T> GetValidator()
        {
            var commandType = typeof(T);

            if (commandType == typeof(CreateKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new KudoAddCommandValidator();
            }
            else if (commandType == typeof(ListKudosQuery))
            {
                return (IKudoSlashCommandValidator<T>)new ListKudosQueryValidator();
            }
            else if (commandType == typeof(DeleteKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new DeleteKudoCommandValidator();
            }
            else if (commandType == typeof(ReplaceKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new ReplaceKudoCommandValidator();
            }

            throw new System.Exception("Uknown Kudo Command.");
        }
    }
}
