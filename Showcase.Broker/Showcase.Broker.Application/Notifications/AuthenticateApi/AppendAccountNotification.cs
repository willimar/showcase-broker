using MediatR;
using Showcase.Broker.Application.Commands.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Application.Notifications.AuthenticateApi
{
    public class AppendAccountNotification: INotification
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class AppendUserNotification : AppendAccountCommand, INotification
    {

    }
}
