using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.DatabaseSize
{
    [DisplayName("Database Size")]
    [DisplayColumn("Redis")]
    [Description("Shows the given redis database size")]
    public class DatabaseSizeWidget : Metric, IRedisDatabaseConnection, ISchedulable
    {
        [Required]
        [Category("Database Size")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Database Size")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Database Size")]
        [Description("Redis database")]
        public int Database { get; set; }

        [Required]
        [Category("Database Size")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Database Size")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public DatabaseSizeWidget()
        {
            Name = "Database Size";
            Database = 0;
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
