using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.ClientCount
{
    public class ClientCountHandler : IMetricQuery<ClientCountWidget>
    {
        public async Task Handle(MetricQueryRequest<ClientCountWidget> request, CancellationToken cancellationToken)
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
