using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.RejectedConnections
{
    [DisplayName("Rejected Connections")]
    [DisplayColumn("Redis")]
    [Description("Shows the rejected connection count for Redis")]
    public class RejectedConnectionsWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Rejected Connections")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Rejected Connections")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Rejected Connections")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Rejected Connections")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public RejectedConnectionsWidget() {
            Name = "Rejected Connections";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
