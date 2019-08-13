using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.KeyspaceKeysCount
{
    [DisplayName("Keyspace Key Count")]
    [DisplayColumn("Redis")]
    [Description("Shows the total key count of given keyspace of Redis")]
    public class KeyspaceKeysCountWidget : Metric, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Keyspace Key Count")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Keyspace Key Count")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Keyspace Key Count")]
        [Description("Redis database")]
        public int Database { get; set; }

        [Required]
        [Category("Keyspace Key Count")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Keyspace Key Count")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public KeyspaceKeysCountWidget() {
            Name = "Keyspace Key Count";
            Database = 0;
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
