using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.EvictedKeys
{
    [DisplayName("Evicted Keys")]
    [DisplayColumn("Redis")]
    [Description("Number of keys removed due to reaching the maxmemory limit")]
    public class EvictedKeysWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Evicted Keys")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Evicted Keys")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Evicted Keys")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Evicted Keys")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public EvictedKeysWidget() {
            Name = "Evicted Keys";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
