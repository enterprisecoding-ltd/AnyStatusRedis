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

namespace AnyStatus.Plugins.Redis.UsedResidentSetSize
{
    public class UsedResidentSetSizeHandler : IRequestHandler<MetricQueryRequest<UsedResidentSetSizeWidget>>
    {
        public async Task Handle(MetricQueryRequest<UsedResidentSetSizeWidget> request, CancellationToken cancellationToken)
        {
            var usedResidentSetSizeWidget = request.DataContext;

            var multiplexer = RedisHelper.GetConnectionMultiplexer(usedResidentSetSizeWidget);
            var redisServer = multiplexer.GetServer(usedResidentSetSizeWidget.EndPoint);

            var info = await redisServer.InfoAsync("memory");

            var usedMemoryRss = double.Parse(info[0].First(stat => stat.Key == "used_memory_rss").Value);
            var totalSystemMemory = double.Parse(info[0].First(stat => stat.Key == "total_system_memory").Value);
            var usedMemoryRssHuman = info[0].First(stat => stat.Key == "used_memory_rss_human").Value;
            var totalSystemMemoryHuman = info[0].First(stat => stat.Key == "total_system_memory_human").Value;
            var percent = (int)Math.Round((usedMemoryRss / (double)totalSystemMemory) * 100);

            request.DataContext.Progress = percent;
            request.DataContext.Message = $"Used {percent}%{Environment.NewLine}" +
                   $"{usedMemoryRssHuman} used out of {totalSystemMemoryHuman}";

            request.DataContext.Value = usedMemoryRss;

            request.DataContext.State = request.DataContext.Progress >= request.DataContext.ErrorPercentage ? State.Failed : State.Ok;
        }
    }
}
