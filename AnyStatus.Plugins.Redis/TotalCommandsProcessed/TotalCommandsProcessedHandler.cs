using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.TotalCommandsProcessed
{
    public class TotalCommandsProcessedHandler : IRequestHandler<MetricQueryRequest<TotalCommandsProcessedWidget>>
    {
        public async Task Handle(MetricQueryRequest<TotalCommandsProcessedWidget> request, CancellationToken cancellationToken)
        {
            var clientListWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(clientListWidget);
            var redisServer = multiplexer.GetServer(clientListWidget.EndPoint);

            var info = await redisServer.InfoAsync("stats");

            request.DataContext.Value = double.Parse(info[0].First(stat => stat.Key == "total_commands_processed").Value);

            request.DataContext.State = State.Ok;
        }
    }
}
