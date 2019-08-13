using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.TotalConnectionsReceived
{
    [DisplayName("Total Connections Received")]
    [DisplayColumn("Redis")]
    [Description("Shows the connected client list for Redis")]
    public class TotalConnectionsReceivedWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Total Connections Received")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Total Connections Received")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Total Connections Received")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Client List")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public TotalConnectionsReceivedWidget() {
            Name = "Total Connections Received";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
