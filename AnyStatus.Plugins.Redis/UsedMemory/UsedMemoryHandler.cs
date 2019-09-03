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
