using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AnyStatus.Plugins.Redis.BlockedClients
{
    public class BlockedClientsHandler : IRequestHandler<MetricQueryRequest<BlockedClientsWidget>>
    {
        public async Task Handle(MetricQueryRequest<BlockedClientsWidget> request, CancellationToken cancellationToken)
        {
            var BlockedClientWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(BlockedClientWidget);
            var redisServer = multiplexer.GetServer(BlockedClientWidget.EndPoint);

            var info = await redisServer.InfoAsync("clients");

            request.DataContext.Value = double.Parse(info[0].First(stat => stat.Key == "blocked_clients").Value);

            request.DataContext.State = State.Ok;
        }
    }
}
