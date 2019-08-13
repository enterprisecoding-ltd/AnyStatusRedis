using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.KeyspaceExpiresCount
{
    [DisplayName("Keyspace Expires Count")]
    [DisplayColumn("Redis")]
    [Description("Shows the total key count of given keyspace of Redis")]
    public class KeyspaceExpiresCountWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Keyspace Expires Count")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Keyspace Expires Count")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Keyspace Expires Count")]
        [Description("Redis database")]
        public int Database { get; set; }

        [Required]
        [Category("Keyspace Expires Count")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Keyspace Expires Count")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public KeyspaceExpiresCountWidget() {
            Name = "Keyspace Expires Count";
            Database = 0;
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
