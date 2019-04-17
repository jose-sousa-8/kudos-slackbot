namespace KudosSlackbot.Presentation.Api.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class KudosController : ControllerBase
    {
        [HttpPost,
        ProducesResponseType(204),
        Route("")]
        public async Task<IActionResult> CreateKudo(dynamic request)
        {
            return Ok(request);
        }
    }
}
