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

            Assert.IsTrue(widget.Value > 0);
        }
    }
}
