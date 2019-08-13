using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AnyStatus.Plugins.Redis.KeyspaceMisses
{
    public class KeyspaceMissesHandler : IMetricQuery<KeyspaceMissesWidget>
    {
        public async Task Handle(MetricQueryRequest<KeyspaceMissesWidget> request, CancellationToken cancellationToken)
        {
            var BlockedClientWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(BlockedClientWidget);
            var redisServer = multiplexer.GetServer(BlockedClientWidget.EndPoint);

            var info = await redisServer.InfoAsync("stats");

            request.DataContext.Value = double.Parse(info[0].First(stat => stat.Key == "keyspace_misses").Value);

            request.DataContext.State = State.Ok;
        }
    }
}
