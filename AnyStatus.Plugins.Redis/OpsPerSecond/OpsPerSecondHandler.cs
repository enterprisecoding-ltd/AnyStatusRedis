﻿using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AnyStatus.Plugins.Redis.OpsPerSecond
{
    public class OpsPerSecondHandler : IMetricQuery<OpsPerSecondWidget>
    {
        public async Task Handle(MetricQueryRequest<OpsPerSecondWidget> request, CancellationToken cancellationToken)
        {
            var BlockedClientWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(BlockedClientWidget);
            var redisServer = multiplexer.GetServer(BlockedClientWidget.EndPoint);

            var info = await redisServer.InfoAsync("stats");

            request.DataContext.Value = double.Parse(info[0].First(stat => stat.Key == "instantaneous_ops_per_sec").Value);

            request.DataContext.State = State.Ok;
        }
    }
}
