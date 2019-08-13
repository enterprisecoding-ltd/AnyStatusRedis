using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AnyStatus.Plugins.Redis.UsedResidentSetSize
{
    [DisplayName("Used Resident Set Size")]
    [DisplayColumn("Redis")]
    [Description("Shows Resident Set Size used by Redis")]
    public class UsedResidentSetSizeWidget : Sparkline, IRedisConnection, ISchedulable, IReportProgress
    {
        [Required]
        [Category("Used Resident Set Size")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Used Resident Set Size")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Used Resident Set Size")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Used Resident Set Size")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        [Category("Used Resident Set Size")]
        [DisplayName("Show progress bar")]
        [Description("Should the status show a bar displaying how full the drive is?")]
        public bool ShowProgress { get; set; } = true;

        [Category("Used Resident Set Size")]
        [DisplayName("Error percentage")]
        [Description("At what percentage should this Node error?")]
        public int ErrorPercentage { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public int Progress
        {
            get => (Value is int) ? (int)Value : -1;
            set
            {
                Value = value;

                OnPropertyChanged();
            }
        }

        public UsedResidentSetSizeWidget() {
            Name = "Used Resident Set Size";
            ErrorPercentage = 85;
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
