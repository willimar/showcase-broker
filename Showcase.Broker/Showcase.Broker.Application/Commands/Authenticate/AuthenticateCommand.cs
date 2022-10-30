using MediatR;
using Showcase.Broker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Application.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<IResponse>
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
