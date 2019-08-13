using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.ClientCount
{
    [DisplayName("Client Count")]
    [DisplayColumn("Redis")]
    [Description("Shows the connected Client Count for Redis")]
    public class ClientCountWidget : Metric, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Client Count")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Client Count")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Client Count")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Client Count")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public ClientCountWidget() {
            Name = "Client Count";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
