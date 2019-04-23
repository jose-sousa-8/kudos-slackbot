namespace KudosSlackbot.Presentation.Api.Controllers
{
    using System;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Application.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class KudosController : BaseController
    {
        private IKudoCommandFactory kudoCommandFactory;

        public KudosController(IMediator mediator, IKudoCommandFactory kudoCommandFactory) : base(mediator)
        {
            this.kudoCommandFactory = kudoCommandFactory;
        }

        [HttpPost,
        ProducesResponseType(200),
        Route("")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> CreateKudo([FromForm] SlashCommandDto request)
        {
            try
            {
                var command = kudoCommandFactory.CreateKudoCommand(request);

                var response = await Mediator.Send(command);

                return Ok(response);
            }
            catch (JsonReaderException)
            {
                return BadRequest("Invalid form format.");
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is KudoSlashCommandValidationException)
                {
                    return BadRequest(ex.Message);
                }

                throw ex;
            }
        }
    }
}
