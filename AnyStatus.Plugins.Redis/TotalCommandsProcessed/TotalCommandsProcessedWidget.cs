using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.TotalCommandsProcessed
{
    [DisplayName("Total Commands Processed")]
    [DisplayColumn("Redis")]
    [Description("Shows total command processed by Redis")]
    public class TotalCommandsProcessedWidget : Metric, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Total Commands Processed")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Total Commands Processed")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Total Commands Processed")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Total Commands Processed")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public TotalCommandsProcessedWidget() {
            Name = "Total Commands Processed";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
