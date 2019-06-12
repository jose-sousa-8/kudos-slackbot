using System.Collections.Generic;
using System.Text;

namespace KudosSlackbot.Domain.Services
{
    public class ValidationResult : IValidationResult
    {
        public IEnumerable<string> Errors { get; set; }

        public string ErrorMessage
        {
            get => this.SetErrorMessage();
        }

        private string SetErrorMessage()
        {
            var errorMsgBuilder = new StringBuilder();

            foreach (var error in this.Errors)
            {
                errorMsgBuilder.Append($"{error}; ");
            }

            return errorMsgBuilder.ToString();
        }
    }
}