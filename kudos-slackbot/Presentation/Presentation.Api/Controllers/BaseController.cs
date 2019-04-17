namespace KudosSlackbot.Presentation.Api.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}