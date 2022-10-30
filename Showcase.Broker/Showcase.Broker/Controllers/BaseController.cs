using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Showcase.Broker.Controllers
{
    [EnableCors(SwaggerSetup.AllowAnyOrigins)]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [IgnoreAntiforgeryToken(Order = 1001)]
    [Authorize]
    public abstract class BaseController: ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
