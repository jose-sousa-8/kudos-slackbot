namespace KudosSlackbot.Presentation.Api.Controllers
{
    using System;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestSlackApiController : BaseController
    {
        public TestSlackApiController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost,
        ProducesResponseType(200),
        Route("")]
        public async Task<IActionResult> TestSlackApi()
        {
            try
            {
                var querySlackApiQuery = new TestSlackApiQuery();

                var result = await base.Mediator.Send(querySlackApiQuery);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}