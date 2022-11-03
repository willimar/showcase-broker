using DataCore.Domain.Interfaces;

namespace Showcase.Broker.Application.Interfaces
{
    public interface IResponse
    {
        public int StatusCode { get; set; }
        public object? Data { get; set; }
        public List<IHandleMessage> Messages { get; set; }
    }
}
