/*
Anystatus Redis plugin
Copyright (C) 2019  Enterprisecoding (Fatih Boy)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AnyStatus.Plugins.Redis.KeyspaceKeysCount
{
    public class KeyspaceKeysCountHandler : IMetricQuery<KeyspaceKeysCountWidget>
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
