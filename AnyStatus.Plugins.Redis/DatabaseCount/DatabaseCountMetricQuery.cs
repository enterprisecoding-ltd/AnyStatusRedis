using AnyStatus.API;
using AnyStatus.Plugins.Redis.Helpers;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.DatabaseCount
{
    public class DatabaseCountMetricQuery : IMetricQuery<DatabaseCountWidget>
    {
        public async Task Handle(MetricQueryRequest<DatabaseCountWidget> request, CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(() =>
            {
                var databaseCountWidget = request.DataContext;

                var multiplexer = RedisHelper.GetConnectionMultiplexer(databaseCountWidget);
                var redisServer = multiplexer.GetServer(databaseCountWidget.EndPoint);

                var databaseCount = redisServer.DatabaseCount;

                request.DataContext.Value = databaseCount;
                request.DataContext.State = State.Ok;
            });
        }
    }
}
