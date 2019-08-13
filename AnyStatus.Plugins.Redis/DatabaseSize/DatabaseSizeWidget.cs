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
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Database Size")]
        [Description("Redis database")]
        public int Database { get; set; }

        [Required]
        [Category("Database Size")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

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
        }
    }
}
