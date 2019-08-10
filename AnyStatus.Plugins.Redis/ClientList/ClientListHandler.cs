using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.ClientList
{
    public class ClientListHandler : IRequestHandler<MetricQueryRequest<ClientListWidget>>
    {
        public async Task Handle(MetricQueryRequest<ClientListWidget> request, CancellationToken cancellationToken)
        {
            var clientListWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(clientListWidget);
            var redisServer = multiplexer.GetServer(clientListWidget.EndPoint);

            var clientList = await redisServer.ClientListAsync();
            request.DataContext.Value = clientList.Length;

            request.DataContext.State = State.Ok;
        }
    }
}
