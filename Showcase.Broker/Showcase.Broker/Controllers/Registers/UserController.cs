using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Showcase.Broker.Application.Commands.Authenticate;
using Showcase.Broker.Application.Models;
using System.Collections.Generic;

namespace Showcase.Broker.Controllers.Registers
{
    [ApiExplorerSettings(GroupName = "Registers")]
    [ApiVersion("1", Deprecated = false)]
    public class UserController: BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("register-account")]
        [AllowAnonymous]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async ValueTask<IActionResult> RegisterAccount([FromBody] AppendAccountCommand appendAccount)
        {
            var response = await this._mediator.Send(appendAccount);
            return await ValueTask.FromResult(Ok(response));
        }

        [HttpPost("register-user")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async ValueTask<IActionResult> RegisterUser([FromBody] AppendAccountCommand appendAccount)
        {
            var response = await this._mediator.Send(appendAccount);
            return await ValueTask.FromResult(Ok(response));
        }

        [HttpPut("change-password")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async ValueTask<IActionResult> Change([FromBody] ChangePasswordCommand changePassword)
        {
            var response = await this._mediator.Send(changePassword);
            return await ValueTask.FromResult(Ok(response));
        }
    }
}
