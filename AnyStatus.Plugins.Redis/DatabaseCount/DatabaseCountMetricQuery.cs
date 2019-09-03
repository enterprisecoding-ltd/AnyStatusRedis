/*
Anystatus Redis plugin
Copyright 2019 Fatih Boy

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */
using AnyStatus.API;
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
