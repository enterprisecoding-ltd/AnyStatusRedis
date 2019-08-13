using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AnyStatus.Plugins.Redis.KeyspaceExpiresCount
{
    public class KeyspaceExpiresCountHandler : IRequestHandler<MetricQueryRequest<KeyspaceExpiresCountWidget>>
    {
        public async Task Handle(MetricQueryRequest<KeyspaceExpiresCountWidget> request, CancellationToken cancellationToken)
        {
            var keyspaceKeysCountWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(keyspaceKeysCountWidget);
            var redisServer = multiplexer.GetServer(keyspaceKeysCountWidget.EndPoint);
            var databaseKey = "db" + keyspaceKeysCountWidget.Database;

            var info = await redisServer.InfoAsync("keyspace");
            var keyspaceInfo = info[0].FirstOrDefault(x => x.Key == databaseKey).Value;

            if (keyspaceInfo == null)
            {
                request.DataContext.State = State.Invalid;
            }

            var keyspaceInfoDictionary = keyspaceInfo.Split(',')
                .Select(value => value.Split('='))
                .ToDictionary(pair => pair[0], pair => pair[1]);


            request.DataContext.Value = double.Parse(keyspaceInfoDictionary["expires"]);

            request.DataContext.State = State.Ok;
        }
    }
}
