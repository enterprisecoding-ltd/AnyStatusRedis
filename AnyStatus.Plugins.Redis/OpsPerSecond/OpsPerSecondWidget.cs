using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.OpsPerSecond
{
    [DisplayName("Operations Per second")]
    [DisplayColumn("Redis")]
    [Description("Total number of redis commands processed per second")]
    public class OpsPerSecondWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Operations Per second")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Operations Per second")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Operations Per second")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Operations Per second")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public OpsPerSecondWidget() {
            Name = "Operations Per second";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
