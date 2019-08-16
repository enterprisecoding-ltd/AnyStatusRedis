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
using System;
using System.Threading;
using System.Threading.Tasks;
using AnyStatus.API;
using AnyStatus.Plugins.Redis.KeyspaceExpiresCount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.Plugins.RedisTests
{
    [TestClass]
    public class KeyspaceExpiresCountTests
    {
        [TestMethod]
        public async Task KeyspaceExpiresCount()
        {
            var widget = new KeyspaceExpiresCountWidget
            {
                EndPoint = "127.0.0.1:6379",
                Password = "abc1234"
            };

            var request = MetricQueryRequest.Create(widget);

            var handler = new KeyspaceExpiresCountHandler();

            await handler.Handle(request, CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(State.Ok, widget.State);
        }
    }
}
