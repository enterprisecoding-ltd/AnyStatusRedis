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
using System;

namespace AnyStatus.Plugins.Redis.UsedMemory
{
    public class UsedMemoryHandler : IRequestHandler<MetricQueryRequest<UsedMemoryWidget>>
    {
        public async Task Handle(MetricQueryRequest<UsedMemoryWidget> request, CancellationToken cancellationToken)
        {
            var usedMemoryWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(usedMemoryWidget);
            var redisServer = multiplexer.GetServer(usedMemoryWidget.EndPoint);

            var info = await redisServer.InfoAsync("memory");

            var usedMemory = double.Parse(info[0].First(stat => stat.Key == "used_memory").Value);
            var totalSystemMemory = double.Parse(info[0].First(stat => stat.Key == "total_system_memory").Value);
            var usedMemoryHuman = info[0].First(stat => stat.Key == "used_memory_human").Value;
            var totalSystemMemoryHuman = info[0].First(stat => stat.Key == "total_system_memory_human").Value;
            var percent = (int)Math.Round((usedMemory / (double)totalSystemMemory) * 100);

            request.DataContext.Progress = percent;
            request.DataContext.Message = $"Used {percent}%{Environment.NewLine}" +
                   $"{usedMemoryHuman} used out of {totalSystemMemoryHuman}";

            request.DataContext.Value = usedMemory;

            request.DataContext.State = request.DataContext.Progress >= request.DataContext.ErrorPercentage ? State.Failed : State.Ok;
        }
    }
}
