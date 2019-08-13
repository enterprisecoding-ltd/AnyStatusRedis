using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.RejectedConnections
{
    [DisplayName("Rejected Connections")]
    [DisplayColumn("Redis")]
    [Description("Shows the number of connections rejected due to hitting maxclient limit")]
    public class RejectedConnectionsWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Rejected Connections")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Rejected Connections")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Rejected Connections")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Rejected Connections")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public RejectedConnectionsWidget() {
            Name = "Rejected Connections";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
