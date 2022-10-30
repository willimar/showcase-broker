using MediatR;
using Showcase.Broker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Application.Commands.Authenticate
{
    public class RefreshTokenCommand: IRequest<IResponse>
    {
        public string Value { get; set; } = string.Empty;
    }
}
