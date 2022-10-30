using MediatR;
using Showcase.Broker.Application.Interfaces;

namespace Showcase.Broker.Application.Commands.Authenticate
{
    public class ChangePasswordCommand : IRequest<IResponse>
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
