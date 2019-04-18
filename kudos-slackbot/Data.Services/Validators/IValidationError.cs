namespace KudosSlackbot.Domain.Services
{
    using System.Collections.Generic;

    public interface IValidationResult
    {
        IEnumerable<string> Errors
        {
            get; set;
        }

        string ErrorMessage { get; }
    }
}