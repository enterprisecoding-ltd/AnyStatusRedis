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
using System.Linq;

namespace AnyStatus.Plugins.Redis.KeyspaceKeysCount
{
    public class KeyspaceKeysCountHandler : IRequestHandler<MetricQueryRequest<KeyspaceKeysCountWidget>>
    {
        public async Task Handle(MetricQueryRequest<KeyspaceKeysCountWidget> request, CancellationToken cancellationToken)
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


            request.DataContext.Value = double.Parse(keyspaceInfoDictionary["keys"]);

            request.DataContext.State = State.Ok;
        }
    }
}
