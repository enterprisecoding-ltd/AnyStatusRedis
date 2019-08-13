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
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Evicted Keys")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Evicted Keys")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public EvictedKeysWidget() {
            Name = "Evicted Keys";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
