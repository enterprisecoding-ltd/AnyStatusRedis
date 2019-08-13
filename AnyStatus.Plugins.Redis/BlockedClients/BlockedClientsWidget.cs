using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.BlockedClients
{
    [DisplayName("Blocked Clients")]
    [DisplayColumn("Redis")]
    [Description("Clients blocked while waiting on BLPOP, BRPOP, or BRPOPLPUSH")]
    public class BlockedClientsWidget : Metric, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Blocked Clients")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Blocked Clients")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public BlockedClientsWidget() {
            Name = "Blocked Clients";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
