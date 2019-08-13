using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.TotalConnectionsReceived
{
    [DisplayName("Total Connections Received")]
    [DisplayColumn("Redis")]
    [Description("Shows total connection received by Redis")]
    public class TotalConnectionsReceivedWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Total Connections Received")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Total Connections Received")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Total Connections Received")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Total Connections Received")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public TotalConnectionsReceivedWidget() {
            Name = "Total Connections Received";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
