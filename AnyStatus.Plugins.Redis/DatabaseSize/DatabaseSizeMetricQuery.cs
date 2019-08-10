using AnyStatus.API;
using AnyStatus.Plugins.Redis.Helpers;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.DatabaseSize
{
    public class DatabaseSizeMetricQuery : IMetricQuery<DatabaseSizeWidget>
    {
        public async Task Handle(MetricQueryRequest<DatabaseSizeWidget> request, CancellationToken cancellationToken)
        {
            var databaseSizeWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(databaseSizeWidget);
            var redisServer = multiplexer.GetServer(databaseSizeWidget.EndPoint);

            var databaseSize = await redisServer.DatabaseSizeAsync(database: databaseSizeWidget.Database);

            request.DataContext.Value = SizeFormatter.FormatSize(databaseSize);
            request.DataContext.State = State.Ok;
        }
    }
}
