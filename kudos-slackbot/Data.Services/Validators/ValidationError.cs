using System.Collections.Generic;

namespace KudosSlackbot.Domain.Services
{
    public class ValidationResult : IValidationResult
    {
        public IEnumerable<string> Errors { get; set; }

        public string ErrorMessage
        {
            get => this.SetErrorMessage(this.Errors);
        }

        private string SetErrorMessage(IEnumerable<string> Errors)
        {
            string errorMsg = string.Empty;

            foreach (var error in this.Errors)
            {
                errorMsg += string.Format($"{error}; ");
            }

            return errorMsg;
        }
    }
}