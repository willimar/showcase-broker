using DataCore.Domain.Extensions;
using DataCore.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Showcase.Broker.Application.Interfaces;

namespace Showcase.Broker.Application.Handlers
{
    public class BaseHandler
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger _logger;
        protected readonly IUser? _user;
        protected readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseHandler(IMediator mediator, ILogger logger, IUser? user, AppSettings appSettings, IHttpContextAccessor httpContextAccessor)
        {
            this._mediator = mediator;
            this._logger = logger;
            this._user = user;
            this._appSettings = appSettings;
            this._httpContextAccessor = httpContextAccessor;
        }

        protected async Task SendNotification(INotification notification)
        {
            _ = this._mediator.Publish(notification);
            await Task.CompletedTask;
        }

        protected Dictionary<string, string> GetAnonymousHeaders()
        {
            Dictionary<string, string> response = new()
            {
                { "Content-Type", "application/json" },
                { "SystemSource", this._appSettings.SystemSource },
                { "Sec-Fetch-Mode", "cors" },
                { "Sec-Fetch-Site", "same-origin" },
                { "x-vhost", string.Empty },
            };

            return response;
        }

        protected Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> response = this.GetAnonymousHeaders();
            var authorization = this._httpContextAccessor.HttpContext.Request.Headers["authorization"];
            var proxyAuthorization = this._httpContextAccessor.HttpContext.Request.Headers["proxyAuthorization"];

            response["authorization"] = authorization;
            response["proxyAuthorization"] = proxyAuthorization;

            return response;
        }

        protected async Task<IResponse> ResponseTo(HttpResponseMessage responseMessage)
        {
            var response = new Response(responseMessage);

            this._httpContextAccessor.HttpContext.Response.StatusCode = responseMessage.StatusCode.ToInteger();

            return await Task.FromResult(response);
        }

        protected async Task<IResponse> ResponseTo<T>(T? data, IEnumerable<IHandleMessage>? messages, int statusCode)
        {
            var response = new Response(data, messages, statusCode);

            this._httpContextAccessor.HttpContext.Response.StatusCode = statusCode;

            return await Task.FromResult(response);
        }

        private class Response : IResponse
        {
            public int StatusCode { get; set; } = 200;
            public object? Data { get; set; }
            public List<IHandleMessage> Messages { get; set; } = new();

            public Response(HttpResponseMessage responseMessage)
            {
                this.StatusCode = responseMessage.StatusCode.ToInteger();
                this.Data = null;
            }

            public Response(object? data, IEnumerable<IHandleMessage>? messages, int statusCode)
            {
                this.Data = data ?? new();
                this.Messages = messages?.ToList() ?? new();
                this.StatusCode = statusCode;
            }
        }
    }
}
