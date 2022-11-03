using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Showcase.Broker.Application.Interfaces;
using System.Net;

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

        protected async Task<IActionResult> ResponseFrom(IResponse result)
        {
            int statusCode = result.StatusCode;

            await Task.CompletedTask;

            switch (statusCode)
            {
                case (int)HandlesCode.Accepted:
                    return Accepted(result);
                case (int)HandlesCode.Ok:
                    return Ok(result);
                case (int)HandlesCode.ValueNotFound:
                    return NotFound(result);
                case (int)HandlesCode.InternalException:
                    return StatusCode(500, result);
                case (int)HandlesCode.BadRequest:
                    return BadRequest(result);
                case 401:
                    return Unauthorized(result);
                default:
                    return Accepted(result);
            }
        }
    }
}
