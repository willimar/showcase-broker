using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;

namespace Showcase.Broker
{
    internal class UserModel : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public string UserName {  get; set; } = string.Empty;
        public string FullName {  get; set; } = string.Empty;
        public string UserEmail {  get; set; } = string.Empty;
        public Guid Id {  get; set; }
        public DateTime Created {  get; set; }
        public DateTime Modified {  get; set; }
        public StatusRecord Status {  get; set; }
        public Guid TenantId {  get; set; }
        public Guid GroupId {  get; set; }

        public UserModel(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }
    }
}
