namespace KudosSlackbot.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

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
