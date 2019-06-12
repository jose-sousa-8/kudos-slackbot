namespace KudosSlackbot.Presentation.Api.Controllers
{
    using System;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SlackUsersController : BaseController
    {
        public SlackUsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost,
        ProducesResponseType(200),
        Route("")]
        public async Task<IActionResult> GetUserInfo([FromQuery] string userId, [FromQuery(Name = "include_local")] bool includeLocal = false)
        {
            try
            {
                var getUserInfoQuery = new GetUserInfoQuery
                {
                    UserId = userId,
                    IncludeLocal = includeLocal
                };

                var result = await base.Mediator.Send(getUserInfoQuery);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}