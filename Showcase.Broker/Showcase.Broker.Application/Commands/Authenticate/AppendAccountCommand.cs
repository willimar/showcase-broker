using MediatR;
using Showcase.Broker.Application.Interfaces;

namespace Showcase.Broker.Application.Commands.Authenticate
{
    public class AppendAccountCommand : IRequest<IResponse>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class AppendUserCommand : AppendAccountCommand
    {

    }
}
