using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.DatabaseSize
{
    public class DatabaseSizeWidget : Metric, IRedisDatabaseConnection, ISchedulable
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
        [Description("Redis database")]
        public int Database { get; set; }

        [Required]
        [Category("Client List")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Enable SSL")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public DatabaseSizeWidget()
        {
            Database = 0;
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
