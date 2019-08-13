using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.DatabaseCount
{
    [DisplayName("Database Count")]
    [DisplayColumn("Redis")]
    [Description("Shows database size on Redis")]
    public class DatabaseCountWidget : Metric, IRedisDatabaseConnection, ISchedulable
    {
        [Required]
        [Category("Database Count")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Database Count")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Database Count")]
        [Description("Redis database")]
        public int Database { get; set; }

        [Required]
        [Category("Database Count")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Database Count")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public DatabaseCountWidget()
        {
            Name = "Database Count";
            Database = 0;
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}
