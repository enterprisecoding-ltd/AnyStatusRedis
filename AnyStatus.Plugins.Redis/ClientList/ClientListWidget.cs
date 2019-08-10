using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.ClientList
{
    [DisplayName("Client List")]
    [DisplayColumn("Redis")]
    [Description("Shows the connected client list for Redis")]
    public class ClientListWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Client List")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Client List")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Client List")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Client List")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public ClientListWidget() {
            Name = "Client List";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
