﻿/*
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
using System.Threading;
using System.Threading.Tasks;
using AnyStatus.API;
using AnyStatus.Plugins.Redis.UsedResidentSetSize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.Plugins.RedisTests
{
    [TestClass]
    public class UsedResidentSetSizeTests
    {
        [TestMethod]
        public async Task UsedResidentSetSize()
        {
            var widget = new UsedResidentSetSizeWidget
            {
                EndPoint = "127.0.0.1:6379",
                Password = "abc1234"
            };

            var request = MetricQueryRequest.Create(widget);

            var handler = new UsedResidentSetSizeHandler();

            await handler.Handle(request, CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(State.Ok, widget.State);
        }
    }
}
