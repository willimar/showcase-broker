using MediatR;
using Showcase.Broker.Application.Notifications.AuthenticateApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Application.EventHandlers.Users
{
    public class AutenticateApiEventHandle :
        INotificationHandler<AppendAccountNotification>,
        INotificationHandler<AppendUserNotification>,
        INotificationHandler<ChangePasswordNotification>
    {
        public AutenticateApiEventHandle()
        {
        }

        public async Task Handle(ChangePasswordNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Handle(AppendUserNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Handle(AppendAccountNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
