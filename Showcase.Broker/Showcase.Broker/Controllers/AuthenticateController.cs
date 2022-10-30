using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Showcase.Broker.Application.Commands.Authenticate;
using Showcase.Broker.Application.Models;

namespace Showcase.Broker.Controllers
{
    [ApiExplorerSettings(GroupName = "Authenticate")]
    [ApiVersion("1", Deprecated = false)]
    public class AuthenticateController: BaseController
    {
        public AuthenticateController(IMediator mediator) : base(mediator)
        {
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async ValueTask<IActionResult> Authenticate([FromBody] AuthenticateCommand authenticate)
        {
            var response = await this._mediator.Send(authenticate);
            return await ValueTask.FromResult(Ok(response));
        }

        
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet("refresh-token")]
        public async ValueTask<IActionResult> RefreshToken([FromBody] RefreshTokenCommand refreshToken)
        {
            var response = await this._mediator.Send(refreshToken);
            return await ValueTask.FromResult(Ok(response));
        }
    }
}
