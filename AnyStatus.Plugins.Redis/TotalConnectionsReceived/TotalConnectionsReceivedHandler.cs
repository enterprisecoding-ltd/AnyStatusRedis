using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.TotalConnectionsReceived
{
    public class TotalConnectionsReceivedHandler : IMetricQuery<TotalConnectionsReceivedWidget>
    {
        public async Task Handle(MetricQueryRequest<TotalConnectionsReceivedWidget> request, CancellationToken cancellationToken)
        {
            var totalConnectionsReceivedWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(totalConnectionsReceivedWidget);
            var redisServer = multiplexer.GetServer(totalConnectionsReceivedWidget.EndPoint);

            var info = await redisServer.InfoAsync("stats");

            request.DataContext.Value = double.Parse(info[0].First(stat => stat.Key == "total_connections_received").Value);

            request.DataContext.State = State.Ok;
        }
    }
}
