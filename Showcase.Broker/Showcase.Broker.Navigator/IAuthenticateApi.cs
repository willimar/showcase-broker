using Refit;
using Showcase.Broker.Navigator.Dtos.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Navigator
{
    public interface IAuthenticateApi
    {
        #region Authenticate
        [Post("/api/v3/Authenticate/authenticate")]
        Task<HttpResponseMessage> Post([Body] LoginDto value, [HeaderCollection] IDictionary<string, string> headers, CancellationToken cancellationToken);
        
        [Get("/api/v3/Authenticate/refresh-token")]
        Task<HttpResponseMessage> Get([HeaderCollection] IDictionary<string, string> headers, CancellationToken cancellationToken);
        #endregion

        #region Users
        [Post("/api/v3/User/register-account")]
        Task<HttpResponseMessage> Post([Body] AccountDto value, [HeaderCollection] IDictionary<string, string> headers, CancellationToken cancellationToken);
        
        [Post("/api/v3/User/register-user")]
        Task<HttpResponseMessage> Post([Body] UserDto value, [HeaderCollection] IDictionary<string, string> headers, CancellationToken cancellationToken);
        
        [Put("/api/v3/User/change-password")]
        Task<HttpResponseMessage> Put([Body] ChangedPasswordDto value, [HeaderCollection] IDictionary<string, string> headers, CancellationToken cancellationToken);
        #endregion
    }
}
