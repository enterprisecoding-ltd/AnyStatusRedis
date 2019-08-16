/*
Anystatus Redis plugin
Copyright (C) 2019  Enterprisecoding (Fatih Boy)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
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
    public class UsedResidentSetSizeWidget : Metric, IRedisConnection, ISchedulable, IReportProgress
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
