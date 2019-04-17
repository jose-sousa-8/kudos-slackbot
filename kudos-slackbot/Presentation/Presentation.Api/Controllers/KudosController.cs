namespace KudosSlackbot.Presentation.Api.Controllers
{
    using System;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class KudosController : BaseController
    {
        public KudosController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost,
        ProducesResponseType(204),
        Route("")]
        public Task<IActionResult> CreateKudo(dynamic request)
        {
            try
            {
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
