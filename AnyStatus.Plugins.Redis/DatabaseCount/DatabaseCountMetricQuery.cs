﻿/*
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
