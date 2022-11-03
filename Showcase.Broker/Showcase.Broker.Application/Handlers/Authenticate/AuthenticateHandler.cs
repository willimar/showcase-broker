using DataCore.Domain.Interfaces;
using DataCore.Mapper;
using DataCore.Navigator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Showcase.Broker.Application.Commands.Authenticate;
using Showcase.Broker.Application.Interfaces;
using Showcase.Broker.Navigator;
using Showcase.Broker.Navigator.Dtos.Authenticate;

namespace Showcase.Broker.Application.Handlers.Authenticate
{
    public class AuthenticateHandler : BaseHandler,
        IRequestHandler<AuthenticateCommand, IResponse>,
        IRequestHandler<RefreshTokenCommand, IResponse>,
        IRequestHandler<AppendAccountCommand, IResponse>,
        IRequestHandler<AppendUserCommand, IResponse>,
        IRequestHandler<ChangePasswordCommand, IResponse>
    {
        private readonly IMapperProfile<AuthenticateCommand, LoginDto> _loginMapper;

        public AuthenticateHandler(
            IMediator mediator,
            ILogger<AuthenticateHandler> logger,
            IUser? user,
            AppSettings appSettings,
            IHttpContextAccessor httpContextAccessor,
            IMapperProfile<AuthenticateCommand, LoginDto> loginMapper)
            : base(mediator, logger, user, appSettings, httpContextAccessor)
        {
            this._loginMapper = loginMapper;
        }

        public async Task<IResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var navigator = NavigatorBase.Factory<IAuthenticateApi>(this._logger, this._appSettings.Apis.Authenticate);

            if (navigator is null)
            {
                throw new NullReferenceException(nameof(navigator));
            }

            var loginDto = this._loginMapper.Map(request);
            var headers = this.GetAnonymousHeaders();

            var response = await navigator.Post(loginDto, headers, cancellationToken);

            return await this.ResponseTo(response);
        }

        public Task<IResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> Handle(AppendAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> Handle(AppendUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
