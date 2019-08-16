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

namespace AnyStatus.Plugins.Redis.OpsPerSecond
{
    [DisplayName("Operations Per second")]
    [DisplayColumn("Redis")]
    [Description("Total number of redis commands processed per second")]
    public class OpsPerSecondWidget : Metric, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Operations Per second")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Operations Per second")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [Category("Operations Per second")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [Category("Operations Per second")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public OpsPerSecondWidget() {
            Name = "Operations Per second";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
