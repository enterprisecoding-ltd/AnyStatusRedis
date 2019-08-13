using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.KeyspaceMisses
{
    [DisplayName("Keyspace Misses")]
    [DisplayColumn("Redis")]
    [Description("Shows the number of failed lookups of keys")]
    public class KeyspaceMissesWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Keyspace Misses")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Keyspace Misses")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Keyspace Misses")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Keyspace Misses")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public KeyspaceMissesWidget() {
            Name = "Keyspace Misses";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
