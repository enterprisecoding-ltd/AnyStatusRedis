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
using System.Linq;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.TotalCommandsProcessed
{
    public class TotalCommandsProcessedHandler : IMetricQuery<TotalCommandsProcessedWidget>
    {
        public async Task Handle(MetricQueryRequest<TotalCommandsProcessedWidget> request, CancellationToken cancellationToken)
        {
            var totalCommandsProcessedWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(totalCommandsProcessedWidget);
            var redisServer = multiplexer.GetServer(totalCommandsProcessedWidget.EndPoint);

            var info = await redisServer.InfoAsync("stats");

            request.DataContext.Value = double.Parse(info[0].First(stat => stat.Key == "total_commands_processed").Value);

            request.DataContext.State = State.Ok;
        }
    }
}
