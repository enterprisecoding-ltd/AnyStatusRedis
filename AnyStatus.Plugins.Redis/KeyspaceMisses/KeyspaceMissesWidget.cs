using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.KeyspaceMisses
{
    [DisplayName("Keyspace Misses")]
    [DisplayColumn("Redis")]
    [Description("Shows the number of failed lookups of keys")]
    public class KeyspaceMissesWidget : Metric, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Keyspace Misses")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Keyspace Misses")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Keyspace Misses")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Keyspace Misses")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public KeyspaceMissesWidget() {
            Name = "Keyspace Misses";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
