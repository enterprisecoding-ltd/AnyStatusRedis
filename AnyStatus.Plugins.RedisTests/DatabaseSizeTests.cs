using System.Threading;
using System.Threading.Tasks;
using AnyStatus.API;
using AnyStatus.Plugins.Redis.DatabaseSize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.Plugins.RedisTests
{
    [TestClass]
    public class DatabaseSizeTests
    {
        [TestMethod]
        public async Task DatabaseSize()
        {
            var widget = new DatabaseSizeWidget
            {
                EndPoint = "127.0.0.1:6379",
                Password = "abc1234"
            };

            var request = MetricQueryRequest.Create(widget);

            var handler = new DatabaseSizeMetricQuery();

            await handler.Handle(request, CancellationToken.None).ConfigureAwait(false);

            Assert.AreSame(State.Ok, request.DataContext.State);
        }
    }
}
